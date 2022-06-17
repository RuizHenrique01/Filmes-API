
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdiconaSessao([FromBody] CreateSessaoDto sessaoDto){

            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { Id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id){
            Sessao sessao = _context.Sessoes.Find(id);

            if(sessao != null){

                ReadSessaoDto gerenteDto = _mapper.Map<ReadSessaoDto>(sessao);

                return Ok(gerenteDto);
            }

            return NotFound();
        }
    }
}