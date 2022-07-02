using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase{
        
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService){
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Deslogar(){
            Result resultado = _logoutService.Deslogar();
            if(resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }
    }
}