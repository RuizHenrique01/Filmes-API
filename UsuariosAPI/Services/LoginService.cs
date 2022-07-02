using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services{

    public class LoginService{
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService){
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
                
                Token token = _tokenService.CreateToken(usuarioIdentity);
                
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Falha no Login !");
        }
    }
}