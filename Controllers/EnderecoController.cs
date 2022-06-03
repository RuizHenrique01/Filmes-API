using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Data;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase{

        private AppDbContext _context; 

        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto){
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new{ Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperarEnderecos(){
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id){
            Endereco endereco = _context.Enderecos.Find(id);

            if(endereco == null){
                return NotFound();
            }

            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(enderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AutualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto){
            Endereco endereco = _context.Enderecos.Find(id);

            if(endereco == null){
                return NotFound();
            }

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id){
            Endereco endereco = _context.Enderecos.Find(id);

            if(endereco == null){
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }

    }
}