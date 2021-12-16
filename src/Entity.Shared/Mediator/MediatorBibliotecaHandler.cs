using System.Threading.Tasks;
using Entity.Shared.Mensagens;
using MediatR;

namespace Entity.Shared.Mediator
{
    public class MediatorBibliotecaHandler : IMediatorBibliotecaHandler
    {
        private readonly IMediator _mediator;
        public MediatorBibliotecaHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}