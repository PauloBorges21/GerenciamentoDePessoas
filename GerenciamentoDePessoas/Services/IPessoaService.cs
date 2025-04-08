using GerenciamentoDePessoas.Models;

﻿namespace GerenciamentoDePessoas.Services
{
    public interface IPessoa
    {
        Task<List<Pessoa>> ListarTodos();
    }
}
