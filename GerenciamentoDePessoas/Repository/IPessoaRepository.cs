using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository;

public interface IPessoaRepository
{
    Task<List<Pessoa>> BuscarTodos();
    Task<bool>VerificarPessoaExiste(string CPF);
    Task<Pessoa> CriarUsuario(Pessoa pessoa);
}