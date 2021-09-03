using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity_framework.ModelViews
{
    public record ClientePedido
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public string Cliente { get; set; }
        public double ValorTotal { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}