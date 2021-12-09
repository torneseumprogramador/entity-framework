using System.Threading.Tasks;
using Entity.Shared.Mensagens;

namespace Entity.Shared.Handlers
{
    public interface IRequisicaoHandler<T> where T : IRequisicao
    {
        Task Handle(T comando);
    }
}