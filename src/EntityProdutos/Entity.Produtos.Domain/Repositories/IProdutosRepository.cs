using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produtos.Entidades;

namespace Entity.Produtos.Domain.Repositories
{
    public interface IProdutosRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get;}

        Task<IEnumerable<Produto>> BuscarTodos();
        Task<Produto> Buscar(int id);
        Task<IEnumerable<Categoria>> BuscarCategorias();
        Task<bool> ProdutoExiste(int id);
        void Adicionar(Produto produto);
        void Deletar(Produto produto);
        void Atualizar(Produto produto);
    }
}