using Entity.Shared.Mensagens;
using Entity.Clientes.Application.Events;

namespace Entity.Clientes.Application.Handlers
{
    public class ClienteRegistradoEventoHandler : INotificacaoHandler<ClienteRegistradoEvento>
    {
        public ClienteRegistradoEventoHandler()
        {
            
        }
        
        public void Handle(ClienteRegistradoEvento evento)
        {
            //Implementar uma logica de envio de email
        }
    }
}