using FichaCompras.Business;
using FichaCompras.Models;
using Microsoft.AspNetCore.Mvc;

namespace FichaCompras.Controllers
{
    public class SolicitacaoController : Controller
    {
        private readonly SolicitacaoService _service;

        public SolicitacaoController(SolicitacaoService service)
        {
            _service = service;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var solicitacoes = await _service.ObterTodasSolicitacoesAsync();
            return View(solicitacoes);
        }

        // GET: Details
        public async Task<IActionResult> Details(int id)
        {
            var solicitacao = await _service.ObterPorIdAsync(id);
            if (solicitacao == null)
                return NotFound();

            return View(solicitacao);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                await _service.AdicionarSolicitacaoAsync(solicitacao);
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var solicitacao = await _service.ObterPorIdAsync(id);
            if (solicitacao == null)
                return NotFound();

            return View(solicitacao);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Solicitacao solicitacao)
        {
            if (id != solicitacao.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.AtualizarSolicitacaoAsync(solicitacao);
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var solicitacao = await _service.ObterPorIdAsync(id);
            if (solicitacao == null)
                return NotFound();

            return View(solicitacao);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.RemoverSolicitacaoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}