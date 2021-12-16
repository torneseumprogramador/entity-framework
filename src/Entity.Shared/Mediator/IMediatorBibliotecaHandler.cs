using System.Threading.Tasks;
using Entity.Shared.Mensagens;

namespace Entity.Shared.Mediator
{
    public interface IMediatorBibliotecaHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
    }
}