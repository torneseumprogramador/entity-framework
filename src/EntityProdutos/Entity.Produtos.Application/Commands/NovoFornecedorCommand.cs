using Entity.Produtos.Entidades;
using Entity.Shared.Mensagens;

namespace Entity.Produtos.Application.Commands
{
    public class NovoFornecedorCommand : Command
    {
        public NovoFornecedorCommand(string nome, string documentoIdentificacao, TipoFornecedor tipoFornecedor, int enderecoId)
        {
            Nome = nome;
            DocumentoIdentificacao = documentoIdentificacao;
            TipoFornecedor = tipoFornecedor;
            EnderecoId = enderecoId;
        }

        public string Nome { get; private set; }
        public string DocumentoIdentificacao { get; private set; }
        public TipoFornecedor TipoFornecedor {get; private set;}
        public int EnderecoId { get; private set; }
    }
}