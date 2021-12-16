using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Pedidos.Domain.Entidades;

namespace Entity.Pedidos.Domain.Repositories
{
    public interface IPedidosRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get;}

        Task<IEnumerable<Pedido>> BuscarTodosComEndereco();
        Task<Pedido> Buscar(int id);
        Task<Pedido> BuscarComEndereco(int id);
        Task<IEnumerable<Endereco>> BuscarEnderecos();
        Task<bool> PedidoExiste(int id);
        void Adicionar(Pedido pedido);
        void Deletar(Pedido pedido);
        void Atualizar(Pedido pedido);
    }
}