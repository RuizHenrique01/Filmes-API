
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService){
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdiconaSessao([FromBody] CreateSessaoDto sessaoDto){
            ReadSessaoDto readSessaoDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = readSessaoDto.Id}, readSessaoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id){
            ReadSessaoDto sessaoDto = _sessaoService.RecuperarSessaoPorId(id);
            if(sessaoDto != null) return Ok(sessaoDto);
            return NotFound();
        }
    }
}