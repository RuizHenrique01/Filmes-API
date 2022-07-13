using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services{

    public class CadastroService{
        private UserManager<IdentityUser<int>> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;
        private IMapper _mapper;
        private EmailService _emailService;

        public CadastroService(UserManager<IdentityUser<int>> userManager, IMapper mapper, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto usuarioDto){
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password).Result;
            
            var createRole = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;

            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "admin").Result;

            if(resultadoIdentity.Succeeded) {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodeCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[]{usuario.Email}, "Link de ativação", usuarioIdentity.Id, encodeCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest ativaContaRequest)
        {
            IdentityUser<int> userIdentity = _userManager
            .Users
            .FirstOrDefault(u => u.Id == ativaContaRequest.UsuarioId);

            var resultado = _userManager.ConfirmEmailAsync(userIdentity, ativaContaRequest.Codigo).Result;
            if(resultado.Succeeded) return Result.Ok();
            return Result.Fail("Falha na confirmação de email");

        }
    }
}