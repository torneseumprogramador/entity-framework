using System;
using Entity.Shared.Mensagens;

namespace Entity.Clientes.Application.Events
{
    public class ClienteRegistradoEvento : Evento
    {
        public ClienteRegistradoEvento(string nome, DateTime? dataCadastro, string email)
        {
            Nome = nome;
            DataCadastro = dataCadastro;
            Email = email;
        }

        public string Nome { get; set; }
         public DateTime? DataCadastro { get; set; }
         public string Email { get; set; }
    }
}