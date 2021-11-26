using System.Threading.Tasks;
using Entity.Shared.Mensagens;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Shared.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        public List<object> Handlers { get; private set; }

        public MediatorHandler()
        {
            Handlers = new List<object>();
        }

        public Task PublicarEvento<T>(T evento) where T : INotificacao
        {
            var handlers = Handlers
                .Where(x => x.GetType().GetInterfaces().Any(x => x.FullName.Contains(evento.GetType().Name)))
                .ToList();

            if (handlers is not null && handlers.Any()) 
            {
                foreach (var handler in handlers)
                {
                    var notificationHandler = (INotificacaoHandler<T>)handler;
                    notificationHandler.Handle(evento);
                }
            }
            
            return Task.CompletedTask;
        }

        public Task RegistrarEventoHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao
        {
            Handlers.Add(handler);
            return Task.CompletedTask;
        }
    }
}