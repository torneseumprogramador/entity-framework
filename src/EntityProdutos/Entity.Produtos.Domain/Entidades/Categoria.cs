using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Produtos.Entidades
{
    [Table("categorias")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new List<Produto>();
        }
        
        public int Id {get;set;}
        public string Descricao {get;set;}

        //EF - Relacionamento
        public virtual List<Produto> Produtos {get;set;}
    }
}