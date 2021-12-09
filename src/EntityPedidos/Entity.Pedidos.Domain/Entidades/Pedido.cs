using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Entity.Pedidos.Domain.Entidades
{
    [Table("pedidos")]
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoItens = new HashSet<PedidoItem>();
        }

        public int Id { get; set; }
        public string Codigo {get;set;} //Código de rastreio do pedido
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; } //Endereço de entrega do pedido
        public decimal Desconto {get;set;}
        public decimal ValorTotal { get; set; }
        public DateTime Data { get; set; }
        public int? CupomDescontoId {get;set;}
        public PedidoStatus PedidoStatus {get;set;}
    
        //EF- relacionamentos
        public virtual CupomDesconto CupomDesconto {get;set;}
        public virtual ICollection<PedidoItem> PedidoItens {get;set;}
        public virtual Endereco Endereco { get; set;}
    }

    public enum PedidoStatus
    {
        Rascunho = 0,
        Iniciado = 1,
        Pago = 2,
        Cancelado = 3,
        Entregue = 4
    }
}
