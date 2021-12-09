using System.Runtime.InteropServices;
using System;
using System.Threading.Tasks;
using Entity.Pedidos.Application.Commands;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;
using Entity.Shared.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Entity.Pedidos.Application.Handlers
{
    public class RemoverPedidoHandler : IRequisicaoHandler<RemoverPedidoComando>
    {
        private readonly IServiceProvider _serviceProvider;

        public RemoverPedidoHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(RemoverPedidoComando comando)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var pedidosRepository = scope.ServiceProvider.GetRequiredService<IPedidosRepository>();

                var pedido = await pedidosRepository.Buscar(comando.PedidoId);

                if(pedido is null)
                    throw new Exception("O pedido não existe!");

                pedidosRepository.Deletar(pedido);
                await pedidosRepository.UnitOfWork.Commit();
            }
        }
    }
}