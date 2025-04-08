using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository;

public interface IPessoaRepository
{
    Task<List<Pessoa>> BuscarTodos();
}