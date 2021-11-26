using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Produtos.Entidades;
using Entity.Produtos.Domain.Repositories;

namespace entity_framework.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _produtosRepository.BuscarTodos());
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtosRepository.Buscar(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CategoriaId"] = new SelectList(await _produtosRepository.BuscarCategorias(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UrlImagem,Descricao,Valor,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtosRepository.Adicionar(produto);
                await _produtosRepository.UnitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(await _produtosRepository.BuscarCategorias(), "Id", "Descricao");
            return View(produto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtosRepository.Buscar(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UrlImagem,Descricao,Valor")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _produtosRepository.Atualizar(produto);
                    await _produtosRepository.UnitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProdutoExiste(produto.Id))
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
            return View(produto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtosRepository.Buscar(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _produtosRepository.Buscar(id);
            _produtosRepository.Deletar(produto);
            await _produtosRepository.UnitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExiste(int id) => await _produtosRepository.ProdutoExiste(id);
    }
}
