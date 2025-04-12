using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;

namespace GerenciamentoDePessoas.Services
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
            var usuariosBanco = await _pessoaRepository.BuscarTodos();
            return usuariosBanco;
        }

        public async Task<Pessoa> CriarUsuario(Pessoa pessoa)
        {
            if (pessoa == null || pessoa.CPF == null)
            {
                throw new ArgumentNullException(nameof(pessoa));
            }
            var usuarioExiste = await _pessoaRepository.VerificarPessoaExiste(pessoa.CPF);
            // Aqui você pode adicionar lógica adicional, como validações ou manipulações antes de salvar no banco de dados.
            if (usuarioExiste)
            {
                throw new Exception("Usuário já esta cadastrado no sistema.");
            }
            await _pessoaRepository.CriarUsuario(pessoa);
            return pessoa;
        }
    }
}
