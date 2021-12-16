using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Produtos.Data.Contexto;
using Entity.Produtos.Entidades;

namespace entity_framework.Controllers
{
    public class ProdutosOldController : Controller
    {
        private readonly ProdutosDbContexto _context;

        public ProdutosOldController(ProdutosDbContexto context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;
            //Consultas separadas a partir de multiplos joins, ponto de atenção que o entity julga quando necessário
            var consulta = await _context.Produtos
                                .Include(x => x.Categoria)
                                .Include(x => x.Fornecedor)
                                .ThenInclude(x => x.Endereco)
                                .AsSplitQuery().ToListAsync();

            //Eager Load - Carregamento adiantado
             var consulta2 = await _context.Produtos
                                .Include(x => x.Categoria)
                                .Include(x => x.Fornecedor)
                                .ThenInclude(x => x.Endereco)
                                .AsSingleQuery().ToListAsync();

            ViewData["CategoriaId"] = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Descricao");
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            
            //Explicit Load 1 para 1 - Carregamento explicito dos relacionamentos
            if(_context.Entry(produto).Reference(x => x.Categoria).IsLoaded)
                await _context.Entry(produto).Reference(x => x.Categoria).LoadAsync();

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoriaId"] = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Descricao");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UrlImagem,Descricao,Valor,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.FornecedorId = 2;
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
