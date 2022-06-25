using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase{
        public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto){
            return Ok();
        }
    }
}