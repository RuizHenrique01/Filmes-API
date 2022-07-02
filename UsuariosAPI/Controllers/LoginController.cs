using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase{

        private LoginService _loginService;
        
        public LoginController(LoginService loginService){
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request){
            Result resultado = _loginService.Login(request);
            if(resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok();   
        }
    }
}