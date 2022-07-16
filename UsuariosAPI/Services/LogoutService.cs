using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services{

    public class LogoutService{
        private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager){
            _signInManager = signInManager;
        }

        public Result Deslogar(){
            var resultado = _signInManager.SignOutAsync();
            if(resultado.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Falha no Logout!");
        }
    }
}