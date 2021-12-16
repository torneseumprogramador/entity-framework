using Entity.Shared.Mensagens;

namespace Entity.Produtos.Application.Events
{
    public class FornecedorInativadoEvent : Event
    {
        public int FornecedorId { get; private set; }

        public FornecedorInativadoEvent(int fornecedorId)
        {
            FornecedorId = fornecedorId;
        }
    }
}