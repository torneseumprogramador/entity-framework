using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using entity_framework.Models;
using entity_framework.Servicos.Database;

namespace entity_framework.Controllers
{
    public class PedidosProdutosController : Controller
    {
        private readonly DbContexto _context;

        public PedidosProdutosController(DbContexto context)
        {
            _context = context;
        }

        // GET: PedidosProdutos
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.PedidosProdutos.Include(p => p.Pedido).Include(p => p.Produto);
            return View(await dbContexto.ToListAsync());
        }

        // GET: PedidosProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidosProdutos
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return View(pedidoProduto);
        }

        // GET: PedidosProdutos/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: PedidosProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,ProdutoId,Valor,Quantidade")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoProduto.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // GET: PedidosProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidosProdutos.FindAsync(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoProduto.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // POST: PedidosProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,ProdutoId,Valor,Quantidade")] PedidoProduto pedidoProduto)
        {
            if (id != pedidoProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoProdutoExists(pedidoProduto.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoProduto.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // GET: PedidosProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoProduto = await _context.PedidosProdutos
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return View(pedidoProduto);
        }

        // POST: PedidosProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoProduto = await _context.PedidosProdutos.FindAsync(id);
            _context.PedidosProdutos.Remove(pedidoProduto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoProdutoExists(int id)
        {
            return _context.PedidosProdutos.Any(e => e.Id == id);
        }
    }
}
