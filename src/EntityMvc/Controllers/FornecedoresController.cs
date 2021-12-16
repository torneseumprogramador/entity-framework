using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Produtos.Entidades;
using Entity.Produtos.Application.Queries;
using Entity.Shared.Mediator;
using Entity.Produtos.Application.Commands;
using Entity.Produtos.Application.Events;

namespace entity_framework.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedoresQueries _fornecedoresQueries;
        private readonly IMediatorBibliotecaHandler _mediator;

        public FornecedoresController(IFornecedoresQueries fornecedoresQueries, 
                                        IMediatorBibliotecaHandler mediator)
        {
            _fornecedoresQueries = fornecedoresQueries;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fornecedoresQueries.BuscarTodos());
        }

        public async Task<IActionResult> Details(int id)
        {
            var fornecedor = await _fornecedoresQueries.Buscar(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["EnderecoId"] = new SelectList(await _fornecedoresQueries.BuscarEnderecos(), "Id", "Bairro");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DocumentoIdentificacao,Ativo,TipoFornecedor,EnderecoId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _mediator.SendCommand(new NovoFornecedorCommand(fornecedor.Nome, 
                fornecedor.DocumentoIdentificacao, 
                fornecedor.TipoFornecedor, fornecedor.EnderecoId));
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(await _fornecedoresQueries.BuscarEnderecos(), "Id", "Bairro");
            return View(fornecedor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _fornecedoresQueries.Buscar(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(await _fornecedoresQueries.BuscarEnderecos(), "Id", "Bairro");
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DocumentoIdentificacao,Ativo,TipoFornecedor,EnderecoId")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.SendCommand(new AtualizarFornecedorCommand(id, fornecedor.Nome, 
                    fornecedor.TipoFornecedor, fornecedor.EnderecoId));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FornecedorExiste(fornecedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var fornecedor = await _fornecedoresQueries.Buscar(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.SendCommand(new RemoverFornecedorCommand(id));
            await _mediator.PublishEvent(new FornecedorInativadoEvent(id));
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FornecedorExiste(int id) => await _fornecedoresQueries.FornecedorExiste(id);
    }
}
