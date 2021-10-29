using System.Collections.Generic;

namespace Entity.Produtos.Entidades
{
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