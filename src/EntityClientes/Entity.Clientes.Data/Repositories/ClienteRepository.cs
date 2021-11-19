using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Clientes.Data.Contexto;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Entity.Clientes.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContexto _contexto;
        public ClienteRepository(ClienteDbContexto contexto)
        {
            _contexto = contexto;
        }

        public IUnitOfWork UnitOfWork => _contexto;

        public void Adicionar(Cliente cliente) => _contexto.Clientes.Add(cliente);

        //public async void Adicionar(Cliente cliente) => await _contexto.AddAsync(cliente);

        public void Atualizar(Cliente cliente) => _contexto.Clientes.Update(cliente);

        public void AtualizarEndereco(Endereco endereco) => _contexto.Enderecos.Update(endereco);

        public async Task<Cliente> BuscarClienteEndereco(int id) => 
            await _contexto.Clientes.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Endereco>> BuscarEnderecos() => await _contexto.Enderecos.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Cliente>> BuscarTodos() =>
            await _contexto.Clientes.AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task<IEnumerable<Cliente>> BuscarTodosComEndereco() => await _contexto.Clientes.Include(x => x.Endereco).ToListAsync();

        public async Task<bool> ClienteExiste(int id) =>  await _contexto.Clientes.AnyAsync(e => e.Id == id);
        
        public void Deletar(Cliente cliente) => _contexto.Clientes.Remove(cliente);

        public void Dispose() => _contexto?.Dispose();
    }
}