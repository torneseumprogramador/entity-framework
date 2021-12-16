using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produtos.Domain.Repositories;
using Entity.Produtos.Entidades;

namespace Entity.Produtos.Application.Queries
{
    public interface IFornecedoresQueries
    {
        Task<IEnumerable<Fornecedor>> BuscarTodos();
        Task<bool> FornecedorExiste(int id);
        Task<IEnumerable<Endereco>> BuscarEnderecos();
        Task<Fornecedor> Buscar(int id);
    }

    public class FornecedoresQueries : IFornecedoresQueries
    {
        private readonly IFornecedoresRepository _fornecedoresRepository;
        public FornecedoresQueries(IFornecedoresRepository fornecedoresRepository)
        {
            _fornecedoresRepository = fornecedoresRepository;
        }

        public Task<Fornecedor> Buscar(int id) => _fornecedoresRepository.Buscar(id);

        public Task<IEnumerable<Endereco>> BuscarEnderecos() => _fornecedoresRepository.BuscarEnderecos();

        public Task<IEnumerable<Fornecedor>> BuscarTodos() => _fornecedoresRepository.BuscarTodos();

        public Task<bool> FornecedorExiste(int id) => _fornecedoresRepository.FornecedorExiste(id);
    }
}