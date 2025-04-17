using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> ListarTodos();
        Task<Pessoa> Criar(Pessoa pessoa);
        Task<Pessoa> BuscarPorId(int id);
        Task<Pessoa> Editar(Pessoa pessoa);
        Task Apagar(int id);
    }
}
