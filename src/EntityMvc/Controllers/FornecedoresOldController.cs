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
    public class FornecedoresOldController : Controller
    {
        private readonly ProdutosDbContexto _context;

        public FornecedoresOldController(ProdutosDbContexto context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Fornecedores
            //.Include(p => p.Cliente)
            .Include(p => p.Endereco);
            return View(await dbContexto.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                //.Include(p => p.Cliente)
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        public IActionResult Create()
        {
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro");
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DocumentoIdentificacao,TipoFornecedor,Ativo,EnderecoId")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                using(var db = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        //Fiz alguma mudança
                        await db.CommitAsync();
                    }
                    catch (System.Exception ex)
                    {
                        await db.RollbackToSavepointAsync("");
                    }
                }
                _context.Entry<Fornecedor>(fornecedor).State = EntityState.Added;
                _context.Set<Fornecedor>().Add(fornecedor);
                await _context.SaveChangesAsync();

                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", fornecedor.ClienteId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro", fornecedor.EnderecoId);
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);

            //Explicit Load 1 para muitos
            if(_context.Entry(fornecedor).Collection(x => x.Produtos).IsLoaded)
                await _context.Entry(fornecedor).Collection(x => x.Produtos).LoadAsync();

            if (fornecedor == null)
            {
                return NotFound();
            }
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", fornecedor.ClienteId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro", fornecedor.EnderecoId);
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DocumentoIdentificacao,TipoFornecedor,Ativo,EnderecoId")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry<Fornecedor>(fornecedor).State = EntityState.Modified;
                    _context.Set<Fornecedor>().Update(fornecedor);
                    await _context.SaveChangesAsync();

                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(fornecedor.Id))
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
            //ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", fornecedor.ClienteId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro", fornecedor.EnderecoId);
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                //.Include(p => p.Cliente)
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);

            _context.Entry<Fornecedor>(fornecedor).State = EntityState.Deleted;
            _context.Set<Fornecedor>().Remove(fornecedor);
            await _context.SaveChangesAsync();

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }

        public void EstadosEntidades()
        {
            //Entidades adicionadas ao contexto
            var entidadesAdicionadas = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added);

            foreach (var entry in _context.ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("RegisterDate").IsModified = false;
            }

            // Verificando se algum entidade no contexto tem mudanças
            var temMudancasOContexto =  _context.ChangeTracker.HasChanges();

            _context.Database.AutoTransactionsEnabled = false;

            //Buscar valores originais de quando a entidade foi inicialmente gerada no contexto
            var valoresIniciais = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).Select(e => e.OriginalValues).ToList();

            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
