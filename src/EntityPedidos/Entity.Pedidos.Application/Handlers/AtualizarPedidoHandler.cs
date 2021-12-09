using System;
using System.Threading.Tasks;
using Entity.Pedidos.Application.Commands;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;
using Entity.Shared.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Entity.Pedidos.Application.Handlers
{
    public class AtualizarPedidoHandler : IRequisicaoHandler<AtualizarPedidoComando>
    {
        private readonly IServiceProvider _serviceProvider;

        public AtualizarPedidoHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(AtualizarPedidoComando comando)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var pedidosRepository = scope.ServiceProvider.GetRequiredService<IPedidosRepository>();
                var pedido = await pedidosRepository.Buscar(comando.Id);


                pedido.Codigo = comando.Codigo;
                pedido.EnderecoId = comando.EnderecoId;
                pedido.Desconto = comando.Desconto;
                pedido.ValorTotal = comando.ValorTotal;
                pedido.CupomDescontoId = comando.CupomDescontoId;
                pedido.PedidoStatus = comando.PedidoStatus;
                pedido.Data = comando.Data;


                if(pedido.ValorTotal < 0)
                    throw new System.Exception("O valor total do pedido não pode ser menor que zero");
                

                pedidosRepository.Atualizar(pedido);
                await pedidosRepository.UnitOfWork.Commit();
            }
        }
    }
}