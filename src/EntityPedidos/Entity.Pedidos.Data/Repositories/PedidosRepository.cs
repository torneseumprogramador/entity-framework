using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Pedidos.Data.Contexto;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Entity.Pedidos.Data.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly PedidosDbContexto _contexto;

        public PedidosRepository(PedidosDbContexto contexto)
        {
            _contexto = contexto;

        }

        public IUnitOfWork UnitOfWork => _contexto;

        public void Adicionar(Pedido pedido) => _contexto.Pedidos.Add(pedido);

        public void Atualizar(Pedido pedido) => _contexto.Pedidos.Update(pedido);

        public async Task<Pedido> Buscar(int id) => await _contexto.Pedidos.FindAsync(id);

        public async Task<Pedido> BuscarComEndereco(int id) => 
            await _contexto.Pedidos.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Endereco>> BuscarEnderecos() => await _contexto.Enderecos.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Pedido>> BuscarTodosComEndereco() => 
            await _contexto.Pedidos.Include(x => x.Endereco).AsNoTrackingWithIdentityResolution().ToListAsync();

        public void Deletar(Pedido pedido) => _contexto.Pedidos.Remove(pedido);

        public void Dispose() => _contexto?.Dispose();

        public async Task<bool> PedidoExiste(int id) => await _contexto.Pedidos.AnyAsync(x => x.Id == id);
    }
}