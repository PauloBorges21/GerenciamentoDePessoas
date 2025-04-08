using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;

﻿namespace GerenciamentoDePessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<List<Pessoa>> ListarTodos()
        {
            var usuariosBanco= await _pessoaRepository.BuscarTodos();
            return usuariosBanco;
        }
    }
}
