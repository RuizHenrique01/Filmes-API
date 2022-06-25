using System;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services{

    public class SessaoService{
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperarSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.Find(id);

            if(sessao != null){

                ReadSessaoDto gerenteDto = _mapper.Map<ReadSessaoDto>(sessao);

                return gerenteDto;
            }

            return null;
        }
    }
}