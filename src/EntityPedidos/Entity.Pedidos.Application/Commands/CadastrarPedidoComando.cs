using Entity.Shared.Mensagens;
using Entity.Pedidos.Domain.Entidades;

namespace Entity.Pedidos.Application.Commands
{
    public class CadastrarPedidoComando : Comando
    {
        public CadastrarPedidoComando(string codigo, int clienteId, int enderecoId, decimal desconto, decimal valorTotal, int? cupomDescontoId, PedidoStatus pedidoStatus)
        {
            Codigo = codigo;
            ClienteId = clienteId;
            EnderecoId = enderecoId;
            Desconto = desconto;
            ValorTotal = valorTotal;
            CupomDescontoId = cupomDescontoId;
            PedidoStatus = pedidoStatus;
        }

        public string Codigo {get; private set;} //Código de rastreio do pedido
        public int ClienteId { get; private set; }
        public int EnderecoId { get; private set; } //Endereço de entrega do pedido
        public decimal Desconto {get;private set;}
        public decimal ValorTotal { get; private set; }
        public int? CupomDescontoId {get;private set;}
        public PedidoStatus PedidoStatus {get;private set;}
    }
}