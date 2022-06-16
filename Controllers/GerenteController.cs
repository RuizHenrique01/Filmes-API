
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase{
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdiconaGerente([FromBody] CreateGerenteDto gerenteDto){

            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { Id = gerente.Id}, gerente);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorId(int id){
            Gerente gerente = _context.Gerentes.Find(id);

            if(gerente != null){

                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return Ok(gerenteDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id){
            Gerente gerente = _context.Gerentes.Find(id);

            if(gerente == null){
                return NotFound();
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}