using Entity.Shared.IntegracaoEventos;
using Entity.Shared.Mensagens;

namespace Entity.Produtos.Application.Handlers
{
    public class ProdutosPedidosEventoHandler : INotificacaoHandler<PedidoFinalizadoEvento>
    {
        public void Handle(PedidoFinalizadoEvento evento)
        {
            //Logica para reservar estoque, emitir nota, acionar logistica
        }
    }
}