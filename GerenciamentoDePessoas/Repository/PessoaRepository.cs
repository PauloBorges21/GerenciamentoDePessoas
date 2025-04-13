using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly GerenciamentoDePessoasContext _contexto;

        public PessoaRepository(GerenciamentoDePessoasContext context)
        {
            _contexto = context;
        }
        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _contexto.Pessoas.ToListAsync();
            return usuariosBanco;
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            try
            {
                await _contexto.Pessoas.AddAsync(pessoa);
                await _contexto.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados:{ex.Message}");
            }

        }

        public async Task<bool> VerificarPessoaExiste(string cpf)
        {
            var usuarioExiste = await _contexto.Pessoas
                .AnyAsync(p => p.CPF == cpf);
            return usuarioExiste;
        }
    }
}
