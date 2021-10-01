using entity_framework.Models;

namespace src.Models
{
    public class PedidoItem
    {
        public int PedidoItemId {get;set;}

        public int ProdutoId {get;set;}
        public string NomeProduto {get;set;}
        public int Quantidade {get;set;}
        public decimal ValorUnitario {get;set;}

        public Pedido Pedido {get;set;}
    } 
}