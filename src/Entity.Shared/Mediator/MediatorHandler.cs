using System.Threading.Tasks;
using Entity.Shared.Mensagens;
using System.Collections.Generic;
using System.Linq;
using Entity.Shared.Handlers;

namespace Entity.Shared.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        public List<object> EventoHandlers { get; private set; }
        public List<object> ComandoHandlers { get; private set; }

        public MediatorHandler()
        {
            EventoHandlers = new List<object>();
            ComandoHandlers = new List<object>();
        }

        public Task PublicarEvento<T>(T evento) where T : INotificacao
        {
            var handlers = EventoHandlers
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
            EventoHandlers.Add(handler);
            return Task.CompletedTask;
        }

        public Task EnviarComando<T>(T comando) where T : IRequisicao
        {
            var handlers = ComandoHandlers
                .Where(x => x.GetType().GetInterfaces().Any(x => x.FullName.Contains(comando.GetType().Name)))
                .ToList();

            if (handlers is not null && handlers.Any()) 
            {
                foreach (var handler in handlers)
                {
                    var notificationHandler = (IRequisicaoHandler<T>)handler;
                    notificationHandler.Handle(comando);
                }
            }
            
            return Task.CompletedTask;
        }

        public Task RegistrarComandoHandler<T>(IRequisicaoHandler<T> handler) where T : IRequisicao
        {
            ComandoHandlers.Add(handler);
            return Task.CompletedTask;
        }
    }
}