using System;
using Entity.Pedidos.Application.Commands;
using Entity.Shared.Handlers;
using Entity.Pedidos.Domain.Entidades;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Entity.Pedidos.Domain.Repositories;

namespace Entity.Pedidos.Application.Handlers
{
    public class CadastrarPedidoHandler : IRequisicaoHandler<CadastrarPedidoComando>
    {
        private readonly IServiceProvider _serviceProvider;
        public CadastrarPedidoHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Handle(CadastrarPedidoComando comando)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var pedidosRepository = scope.ServiceProvider.GetRequiredService<IPedidosRepository>();
                var pedido = new Pedido
                {
                    Codigo = comando.Codigo,
                    ClienteId = comando.ClienteId,
                    EnderecoId = comando.EnderecoId,
                    Desconto = comando.Desconto,
                    ValorTotal = comando.ValorTotal,
                    CupomDescontoId = comando.CupomDescontoId,
                    PedidoStatus = comando.PedidoStatus
                };

                if(pedido.ValorTotal < 0)
                    throw new System.Exception("O valor total do pedido não pode ser menor que zero");
                

                pedidosRepository.Adicionar(pedido);
                await pedidosRepository.UnitOfWork.Commit();
            }
        }
    }
}