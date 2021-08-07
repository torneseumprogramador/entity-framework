using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity_framework.Models
{
    [Table("clientes")]
    public class Cliente
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
        [Column("endereco")]
        [Required]
        public string Endereco { get; set; }

        [Column("observacao", TypeName="text")]
        [Required]
        public string Observacao { get; set; }

    }
}
