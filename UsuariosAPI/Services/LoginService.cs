using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Services{

    public class LoginService{
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager){
            _signInManager = signInManager;
        }

        public Result Login(LoginRequest request){
            Task<SignInResult> resultado = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if(resultado.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha no Login !");
        }
    }
}