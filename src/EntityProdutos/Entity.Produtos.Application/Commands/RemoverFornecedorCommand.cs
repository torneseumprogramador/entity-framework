using Entity.Shared.Mensagens;

namespace Entity.Produtos.Application.Commands
{
    public class RemoverFornecedorCommand : Command
    {
        public RemoverFornecedorCommand(int fornecedorId)
        {
            FornecedorId = fornecedorId;
        }

        public int FornecedorId { get; private set; }
    }
}