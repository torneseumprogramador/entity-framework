using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Pedidos.Domain.Entidades
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EnderecoId { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Data { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
