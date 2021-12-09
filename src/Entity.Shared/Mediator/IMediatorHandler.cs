using System.Threading.Tasks;
using Entity.Shared.Handlers;
using Entity.Shared.Mensagens;

namespace Entity.Shared.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : INotificacao;
        Task EnviarComando<T>(T comando) where T : IRequisicao;
        Task RegistrarEventoHandler<T>(INotificacaoHandler<T> handler) where T : INotificacao;
        Task RegistrarComandoHandler<T>(IRequisicaoHandler<T> handler) where T : IRequisicao;
    }
}