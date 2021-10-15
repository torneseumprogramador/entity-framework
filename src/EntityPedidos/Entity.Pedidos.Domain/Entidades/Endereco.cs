using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Pedidos.Domain.Entidades
{
    public partial class Endereco
    {
        public Endereco()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
