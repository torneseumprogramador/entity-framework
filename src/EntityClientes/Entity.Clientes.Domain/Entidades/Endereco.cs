using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Clientes.Domain.Entidades
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
