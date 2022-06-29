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

        public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto){
            Result resultado = _cadastroService.CadastraUsuario(usuarioDto);
            if(resultado.IsFailed) return BadRequest("Falha ao cadastrar usuário");
            return Ok();
        }
    }
}