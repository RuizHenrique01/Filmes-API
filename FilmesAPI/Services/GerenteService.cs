using System;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services{

    public class GerenteService {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperarGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.Find(id);

            if(gerente != null){

                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return gerenteDto;
            }

            return null;
        }

        public Result DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.Find(id);

            if(gerente == null){
                return Result.Fail("Gerente não encontrado!");            
            }

            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}