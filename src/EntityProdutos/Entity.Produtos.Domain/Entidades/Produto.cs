using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Produtos.Entidades
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int CategoriaId {get;set;}

        //EF - Relacionamento
        public virtual Categoria Categoria {get;set;}
    }
}
