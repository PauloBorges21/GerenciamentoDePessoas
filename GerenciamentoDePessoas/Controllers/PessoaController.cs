using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoDePessoas.Controllers
{
    [Route("Usuario")]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoasService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoasService = pessoaService;
        }

        [Route("Inicio")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //ViewBag.texto = TempData["SucessoRedirecionamento"];
            ViewBag.Cadastro = TempData["SucessoCriacao"];
            var listarPessoas = await _pessoasService.ListarTodos();
            return View(listarPessoas);
        }

        [HttpGet]
        [Route("CriarUsuario")]
        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        [Route("CriarUsuario")]
        public async Task<IActionResult> CriarUsuario(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _pessoasService.CriarUsuario(pessoa);
                    TempData["SucessoCriacao"] = $"O usuário {pessoa.Nome} {pessoa.Sobrenome} cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(pessoa);
            }
            catch (Exception ex)
            {
                TempData["ErroCriacao"] = $"Erro ao cadastrar:( {ex.Message} )";
                throw;
            }



        }

        [Route("Detalhes/{id:int}")]
        public IActionResult DetalhesPessoa(int id)
        {
            ViewBag.texto = "Texto da tema de descrição";
            ViewData["puxa"] = DateTime.Today;

            TempData["SucessoRedirecionamento"] = "Sucesso";

            var listaUsuario = new List<Pessoa>
            {
                new Pessoa { Id = 1, Nome = "Pedro", Sobrenome = "Silva", DataNascimento = DateTime.Now },
                new Pessoa { Id = 2, Nome = "Maria", Sobrenome = "Silva", DataNascimento = DateTime.Now },
                new Pessoa { Id = 3, Nome = "José", Sobrenome = "Silva", DataNascimento = DateTime.Now },
                new Pessoa { Id = 4, Nome = "Paulo", Sobrenome = "Silva", DataNascimento = DateTime.Now }
            };
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("BuscaPorUrl")]
        public IActionResult BuscaPorUrl(string nome, string sobrenome)
        {
            var listaUsuario = new List<Pessoa>
            {
                new Pessoa { Id = 1, Nome = "Pedro", Sobrenome = "Silva", DataNascimento = DateTime.Now },
                new Pessoa { Id = 2, Nome = "Maria", Sobrenome = "Silva", DataNascimento = DateTime.Now },
                new Pessoa { Id = 3, Nome = "José", Sobrenome = "Silva", DataNascimento = DateTime.Now },
                new Pessoa { Id = 4, Nome = "Paulo", Sobrenome = "Silva", DataNascimento = DateTime.Now }
            };

            var pessoaSelecionada = listaUsuario.FirstOrDefault(n => n.Nome == nome && n.Sobrenome == sobrenome);

            return View(pessoaSelecionada);
        }


    }
}
