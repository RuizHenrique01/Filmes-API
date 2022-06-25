using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Data;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;

namespace FilmesAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase{
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService){
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public ActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto){
            ReadEnderecoDto readEnderecoDto = _enderecoService.AdicionaEndereco(enderecoDto);
        
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new{ Id = readEnderecoDto.Id }, readEnderecoDto);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperarEnderecos(){
            return _enderecoService.RecuperarEnderecos();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id){
            ReadEnderecoDto readEnderecoDto =_enderecoService.RecuperarEnderecosPorId(id);
            if(readEnderecoDto == null) return NotFound();
            return Ok(readEnderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AutualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto){
            Result resultado =_enderecoService.AtualizarEndereco(id, enderecoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id){
            Result resultado = _enderecoService.DeletarEndereco(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}