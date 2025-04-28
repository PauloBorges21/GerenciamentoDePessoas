using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoDePessoas.Controllers
{
    [Route("Pessoa")]
    [Authorize]
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

        [HttpGet("Criar")]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _pessoasService.Criar(pessoa);
                    TempData["SucessoCriacao"] = $"O usuário {pessoa.Nome} {pessoa.Sobrenome} cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(pessoa);
            }
            catch (Exception ex)
            {
                TempData["ErroCriacao"] = $"Erro ao cadastrar: ({ex.Message})";
                return View(pessoa);
            }



        }

        [HttpPost("Editar")]
        public async Task<ActionResult> Editar(Pessoa pessoa)
        {
            try
            {
                if (pessoa.Id == 0)
                {
                    throw new Exception("Um Id deve ser informado.");
                }

                var pessoaDb = await _pessoasService.Editar(pessoa);
                TempData["SucessoCriacao"] = $"Pessoa {pessoa.Nome} foi atualizada com sucesso";
                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception ex)
            {
                TempData["ErroEditar"] = $"Erro ao editar: ({ex.Message})";
                return RedirectToAction("Index", "Pessoa");
            }

        }

        [HttpPost("Apagar")]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Um Id deve ser informado.");
                }

                await _pessoasService.Apagar(id);
                TempData["SucessoCriacao"] = $"Pessoa foi deletada com sucesso";
                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception ex)
            {
                TempData["ErroEditar"] = $"Erro ao editar: ({ex.Message})";
                return RedirectToAction("Index", "Pessoa");
            }

        }

        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Um Id deve ser informado.");
                }

                var pessoaDb = await _pessoasService.BuscarPorId(id);
                return View(pessoaDb);
            }
            catch (Exception ex)
            {
                TempData["ErroEditar"] = $"Erro ao editar: ({ex.Message})";
                return RedirectToAction("Index", "Pessoa");
            }

        }

        [HttpGet("TotalPessoas")]
        public async Task<ActionResult> TotalPessoas()
        {
            var totalPessoas = await _pessoasService.BuscarTotal();
            return Ok(totalPessoas);
        }

        [HttpGet]
        [Route("BuscaPessoasNome")]
        public async Task<JsonResult> BuscaPessoasNome(string termo)
        {
            var resultDB = await _pessoasService.BuscaPessoasNome(termo);
            return Json(resultDB);
        }


    }
}
