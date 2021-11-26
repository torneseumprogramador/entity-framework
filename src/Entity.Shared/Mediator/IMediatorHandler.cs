using System.Threading.Tasks;
using Entity.Shared.Mensagens;

namespace Entity.Shared.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : INotificacao;
        Task RegistrarEventoHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao;
    }
}