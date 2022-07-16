using System;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services{

    public class LoginService{
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService){
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result Login(LoginRequest request){
            Task<SignInResult> resultado = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if(resultado.Result.Succeeded) { 
                var usuarioIdentity = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());
                
                var roleIdentity = _signInManager.UserManager.GetRolesAsync(usuarioIdentity).Result.FirstOrDefault();
                
                Token token = _tokenService.CreateToken(usuarioIdentity, roleIdentity);
                
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Falha no Login !");
        }

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if(identityUser == null){
                Result.Fail("Falha na redefinição de senha!");
            }

            IdentityResult result = _signInManager
            .UserManager
            .ResetPasswordAsync(identityUser, request.Token, request.Password)
            .Result;

            if(result.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Falha na redefinição de senha!");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if(identityUser == null){
                Result.Fail("Falha na solicitação de redefinição de senha!");
            }

            string code = _signInManager
            .UserManager
            .GeneratePasswordResetTokenAsync(identityUser).Result;

            return Result.Ok().WithSuccess(code);
        }

        public CustomIdentityUser RecuperaUsuarioPorEmail(string email){
            return _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }
    }
}