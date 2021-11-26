using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Produtos.Entidades;
using Entity.Produtos.Domain.Repositories;

namespace entity_framework.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedoresRepository _fornecedoresRepository;

        public FornecedoresController(IFornecedoresRepository fornecedoresRepository)
        {
            _fornecedoresRepository = fornecedoresRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fornecedoresRepository.BuscarTodos());
        }

        public async Task<IActionResult> Details(int id)
        {
            var fornecedor = await _fornecedoresRepository.Buscar(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["EnderecoId"] = new SelectList(await _fornecedoresRepository.BuscarEnderecos(), "Id", "Bairro");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DocumentoIdentificacao,Ativo,TipoFornecedor,EnderecoId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedoresRepository.Adicionar(fornecedor);
                await _fornecedoresRepository.UnitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(await _fornecedoresRepository.BuscarEnderecos(), "Id", "Bairro");
            return View(fornecedor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _fornecedoresRepository.Buscar(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(await _fornecedoresRepository.BuscarEnderecos(), "Id", "Bairro");
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
                    _fornecedoresRepository.Atualizar(fornecedor);
                    await _fornecedoresRepository.UnitOfWork.Commit();
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
            var fornecedor = await _fornecedoresRepository.Buscar(id);
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
            var fornecedor = await _fornecedoresRepository.Buscar(id);
            _fornecedoresRepository.Deletar(fornecedor);
            await _fornecedoresRepository.UnitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FornecedorExiste(int id) => await _fornecedoresRepository.FornecedorExiste(id);
    }
}
