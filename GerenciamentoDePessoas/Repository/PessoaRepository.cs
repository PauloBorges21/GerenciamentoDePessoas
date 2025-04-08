using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository :IPessoaRepository
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
    }
}
