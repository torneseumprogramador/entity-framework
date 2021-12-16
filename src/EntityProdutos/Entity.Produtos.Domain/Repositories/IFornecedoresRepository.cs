using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produtos.Entidades;

namespace Entity.Produtos.Domain.Repositories
{
    public interface IFornecedoresRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get;}

        Task<IEnumerable<Fornecedor>> BuscarTodos();
        Task<bool> FornecedorExiste(int id);
        Task<IEnumerable<Endereco>> BuscarEnderecos();
        Task<Fornecedor> Buscar(int id);
        Task<Fornecedor> BuscarPorDocumento(string nome);
        void Adicionar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);
        void Atualizar(Fornecedor fornecedor);
    }
}