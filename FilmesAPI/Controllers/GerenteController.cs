
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase{
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService){
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdiconaGerente([FromBody] CreateGerenteDto gerenteDto){
            ReadGerenteDto readGerenteDto =_gerenteService.AdicionaGerente(gerenteDto);
            
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = readGerenteDto.Id}, readGerenteDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id){
            ReadGerenteDto readGerenteDto = _gerenteService.RecuperarGerentePorId(id);
            if(readGerenteDto != null) return Ok(readGerenteDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id){
            Result resultado =_gerenteService.DeletarGerente(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}