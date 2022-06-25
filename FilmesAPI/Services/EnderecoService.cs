using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services{
    
    public class EnderecoService{
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperarEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
        }

        public ReadEnderecoDto RecuperarEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.Find(id);

            if(endereco == null){
                return null;
            }

            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return enderecoDto;
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.Find(id);

            if(endereco == null){
                return Result.Fail("Endereço não encontrado!");
            }

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.Find(id);

            if(endereco == null){
                return Result.Fail("Endereço não encontrado!");
            }

            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}