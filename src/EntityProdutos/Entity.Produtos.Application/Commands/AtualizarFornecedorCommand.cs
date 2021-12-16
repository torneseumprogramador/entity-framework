using Entity.Produtos.Entidades;
using Entity.Shared.Mensagens;

namespace Entity.Produtos.Application.Commands
{
    public class AtualizarFornecedorCommand : Command
    {
        public AtualizarFornecedorCommand(int id ,string nome, TipoFornecedor tipoFornecedor, int enderecoId)
        {
            Id = id;
            Nome = nome;
            TipoFornecedor = tipoFornecedor;
            EnderecoId = enderecoId;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public TipoFornecedor TipoFornecedor {get; private set;}
        public int EnderecoId { get; private set; }
    }
}