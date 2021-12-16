using System;
using Entity.Shared.Mensagens;

namespace Entity.Shared.IntegracaoEventos
{
    public class PedidoFinalizadoEvento : Evento
    {
        public PedidoFinalizadoEvento(int id, string codigo, int clienteId, DateTime data, decimal desconto, decimal valorTotal)
        {
            Id = id;
            Codigo = codigo;
            ClienteId = clienteId;
            Data = data;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }

        public int Id { get; set; }
        public string Codigo {get;set;}
        public int ClienteId { get; set; }
        public DateTime Data { get; set; }
        public decimal Desconto {get;set;}
        public decimal ValorTotal { get; set; }
    }
}