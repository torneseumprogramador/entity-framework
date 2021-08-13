using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity_framework.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(150)]
        [Column("nome")]
        [Required]
        public string Nome { get; set; }

        [MaxLength(255)]
        [Column("url_imagem")]
        public string UrlImagem { get; set; }

        [Column("descricao", TypeName="text")]
        public string Descricao { get; set; }

        [Column("valor")]
        [Required]
        public double Valor { get; set; }

    }
}
