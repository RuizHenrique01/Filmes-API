using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase{
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService){
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto){
            Result resultado = _cadastroService.CadastraUsuario(usuarioDto);
            if(resultado.IsFailed) return BadRequest("Falha ao cadastrar usuário");
            return Ok(resultado.Successes);
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest ativaContaRequest){
            Result resultado = _cadastroService.AtivaContaUsuario(ativaContaRequest);
            if(resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }
    }
}