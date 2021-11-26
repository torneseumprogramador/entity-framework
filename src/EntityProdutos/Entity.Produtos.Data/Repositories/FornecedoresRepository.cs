using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Produtos.Data.Contexto;
using Entity.Produtos.Domain.Repositories;
using Entity.Produtos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entity.Produtos.Data.Repositories
{
    public class FornecedoresRepository : IFornecedoresRepository
    {
        private readonly ProdutosDbContexto _contexto;
        public FornecedoresRepository(ProdutosDbContexto contexto)
        {
            _contexto = contexto;

        }
        
        public IUnitOfWork UnitOfWork => _contexto;

        public void Adicionar(Fornecedor fornecedor) => _contexto.Fornecedores.Add(fornecedor);

        public void Atualizar(Fornecedor fornecedor) => _contexto.Fornecedores.Update(fornecedor);

        public async Task<Fornecedor> Buscar(int id) => await _contexto.Fornecedores.FindAsync(id);

        public async Task<IEnumerable<Fornecedor>> BuscarTodos() => 
            await _contexto.Fornecedores.AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task<IEnumerable<Endereco>> BuscarEnderecos() => await _contexto.Enderecos.AsNoTracking().ToListAsync();

        public void Deletar(Fornecedor fornecedor) => _contexto.Fornecedores.Remove(fornecedor);

        public Task<bool> FornecedorExiste(int id) => _contexto.Fornecedores.AnyAsync(x => x.Id == id);

        public void Dispose() => _contexto?.Dispose();
    }
}