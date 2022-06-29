using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services{

    public class CadastroService{
        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;

        public CadastroService(UserManager<IdentityUser<int>> userManager, IMapper mapper){
            _userManager = userManager;
            _mapper = mapper;
        }

        public Result CadastraUsuario(CreateUsuarioDto usuarioDto){
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDto.Password);
            if(resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}