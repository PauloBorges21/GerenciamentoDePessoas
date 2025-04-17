using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly GerenciamentoDePessoasContext _context;

        public PessoaRepository(GerenciamentoDePessoasContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> BuscarTodos()
        {
            var usuariosBanco = await _context.Pessoas.ToListAsync();
            return usuariosBanco;
        }

        public async Task<Pessoa> Criar(Pessoa pessoa)
        {
            try
            {
                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no banco de dados:{ex.Message}");
            }

        }

        public async Task<bool> VerificarPessoaExiste(string cpf)
        {
            var pessoaExiste = await _context.Pessoas
                .AnyAsync(p => p.CPF == cpf);
            return pessoaExiste;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            try
            {
                var pessoaDB = await _context.Pessoas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (pessoaDB == null)
                {
                    throw new Exception("Pessoa não encontrada.");
                }
                return pessoaDB;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pessoa> Editar(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Update(pessoa);
                await _context.SaveChangesAsync();
                return pessoa;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task Apagar(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
