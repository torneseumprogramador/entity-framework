using Entity.Shared.Mensagens;

namespace Entity.Pedidos.Application.Commands
{
    public class RemoverPedidoComando : Comando
    {
        public RemoverPedidoComando(int pedidoId)
        {
            PedidoId = pedidoId;
        }

        public int PedidoId { get; private set; }         
    }
}