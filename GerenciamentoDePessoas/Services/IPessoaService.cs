using GerenciamentoDePessoas.Models;

﻿namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> ListarTodos();
        Task<Pessoa> Criar(Pessoa pessoa);
    }
}
