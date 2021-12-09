using System;
using Entity.Pedidos.Domain.Entidades;
using Entity.Shared.Mensagens;

namespace Entity.Pedidos.Application.Commands
{
    public class AtualizarPedidoComando : Comando
    {
        public AtualizarPedidoComando(int id ,string codigo, int clienteId, int enderecoId, decimal desconto, decimal valorTotal, int? cupomDescontoId, DateTime data, PedidoStatus pedidoStatus)
        {
            Id = id;
            Codigo = codigo;
            ClienteId = clienteId;
            EnderecoId = enderecoId;
            Desconto = desconto;
            ValorTotal = valorTotal;
            CupomDescontoId = cupomDescontoId;
            Data = data;
            PedidoStatus = pedidoStatus;
        }
        public int Id { get; set; }
        public string Codigo {get; private set;} //Código de rastreio do pedido
        public int ClienteId { get; private set; }
        public int EnderecoId { get; private set; } //Endereço de entrega do pedido
        public decimal Desconto {get;private set;}
        public decimal ValorTotal { get; private set; }
        public int? CupomDescontoId {get;private set;}
        public DateTime Data { get; set; }
        public PedidoStatus PedidoStatus {get;private set;}
    }
}