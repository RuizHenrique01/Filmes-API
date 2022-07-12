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
            return Ok(resultado.Successes);   
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaRequestSenhaUsuario(SolicitaResetRequest request){
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);
            if(resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);   
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request){
            Result resultado = _loginService.ResetaSenhaUsuario(request);
            if(resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);   
        }

    }
}