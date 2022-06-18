using System.Collections.Generic;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data;
using System;
using FilmesAPI.Data.Dtos;
using AutoMapper;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase{

        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdiconaFilme([FromBody] CreateFilmeDto filmeDto){

            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id}, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilme([FromQuery] int? classificacaoEtaria) {

            if(classificacaoEtaria == null){
                return Ok(_context.Filmes);
            }

            List<Filme> filmes = _context.Filmes
            .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
            .ToList();

            if(filmes == null){
                return NotFound();
            }

            List<ReadFilmeDto> filmeDtos = _mapper.Map<List<ReadFilmeDto>>(filmes);

            return Ok(filmeDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id){
            Filme filme = _context.Filmes.Find(id);

            if(filme != null){

                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                filmeDto.HoraDaConsulta = DateTime.Now;
                return Ok(filmeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto){
            Filme filme = _context.Filmes.Find(id);

            if(filme == null){
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id){
            Filme filme = _context.Filmes.Find(id);

            if(filme == null){
                return NotFound();
            }

            _context.Filmes.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
    
}