using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Produtos.Entidades
{
    public class Fornecedor 
    {
        public Fornecedor()
        {
            Produtos = new List<Produto>();
        }
        public int Id {get;set;}
        public string Nome { get; set; }
        public string DocumentoIdentificacao { get; set; }
        public TipoFornecedor TipoFornecedor {get;set;}
        public bool Ativo { get; set; }
        public int EnderecoId { get; set; }

        //EF - Relacionamento
        public virtual List<Produto> Produtos { get; set; }
        public virtual Endereco Endereco {get;set;}
    }

    public enum TipoFornecedor 
    {
        PessoaJuridica = 0, 
        PessoaFisica = 1
    }
 }