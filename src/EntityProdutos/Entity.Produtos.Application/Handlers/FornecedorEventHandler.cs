using System.Threading;
using System.Threading.Tasks;
using Entity.Produtos.Application.Events;
using Entity.Produtos.Application.Queries;
using MediatR;

namespace Entity.Produtos.Application.Handlers
{
    public class FornecedorEventHandler : INotificationHandler<FornecedorInativadoEvent>
    {
        private readonly IFornecedoresQueries _fornecedoresQueries;
        public FornecedorEventHandler(IFornecedoresQueries fornecedoresQueries)
        {
            _fornecedoresQueries = fornecedoresQueries;
        }

        public async Task Handle(FornecedorInativadoEvent notification, CancellationToken cancellationToken)
        {
            var fornecedor = await _fornecedoresQueries.Buscar(notification.FornecedorId);
            //Enviar email notificando;
        }
    }
}