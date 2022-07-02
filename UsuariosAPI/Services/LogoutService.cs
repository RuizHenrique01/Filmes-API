using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Services{

    public class LogoutService{
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager){
            _signInManager = signInManager;
        }

        public Result Deslogar(){
            var resultado = _signInManager.SignOutAsync();
            if(resultado.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Falha no Logout!");
        }
    }
}