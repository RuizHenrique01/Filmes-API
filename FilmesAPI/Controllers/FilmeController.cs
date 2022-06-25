using System.Collections.Generic;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data;
using System;
using FilmesAPI.Data.Dtos;
using AutoMapper;
using System.Linq;
using FilmesAPI.Services;
using FluentResults;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase{
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService){
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdiconaFilme([FromBody] CreateFilmeDto filmeDto){

            ReadFilmeDto readFilmeDto = _filmeService.AdicionaFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = readFilmeDto.Id}, readFilmeDto);
        }

        [HttpGet]
        public IActionResult RecuperarFilme([FromQuery] int? classificacaoEtaria) {

            List<ReadFilmeDto> filmeDtos = _filmeService.RecuperarFilmes(classificacaoEtaria);
            if(filmeDtos == null) return NotFound();
            return Ok(filmeDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id){
            ReadFilmeDto filmeDto = _filmeService.RecuperarFilmePorId(id);
             if(filmeDto == null) return NotFound();
            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto){
            Result resultado = _filmeService.AtualizarFilme(id, filmeDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id){
            Result resultado =_filmeService.DeletarFilme(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
    
}