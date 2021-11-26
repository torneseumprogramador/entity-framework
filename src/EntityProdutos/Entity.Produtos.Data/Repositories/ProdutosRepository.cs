using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produtos.Data.Contexto;
using Entity.Produtos.Domain.Repositories;
using Entity.Produtos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entity.Produtos.Data.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly ProdutosDbContexto _contexto;

        public ProdutosRepository(ProdutosDbContexto contexto)
        {
            _contexto = contexto;
        }

        public IUnitOfWork UnitOfWork => _contexto;

        public void Adicionar(Produto produto) =>
            _contexto.Produtos.Add(produto);

        public async Task<Produto> Buscar(int id) => await _contexto.Produtos.FindAsync(id);

        public async Task<IEnumerable<Produto>> BuscarTodos() => await _contexto.Produtos.AsNoTracking().ToListAsync();

        public void Deletar(Produto produto) => _contexto.Remove(produto);

        public void Atualizar(Produto produto) => _contexto.Update(produto);

        public async Task<IEnumerable<Categoria>> BuscarCategorias() => 
            await _contexto.Categorias.AsNoTracking().ToListAsync();

        public async Task<bool> ProdutoExiste(int id) => await _contexto.Produtos.AnyAsync(x => x.Id == id);

        public void Dispose() => _contexto?.Dispose();
    }
}