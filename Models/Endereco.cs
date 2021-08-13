using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity_framework.Models
{
    [Table("enderecos")]
    public class Endereco
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("logradouro")]
        [MaxLength(255)]
        [Required]
        public string Logradouro { get; set; }

        [Column("cep")]
        [MaxLength(10)]
        [Required]
        public string Cep { get; set; }

        [Column("bairro")]
        [MaxLength(150)]
        [Required]
        public string Bairro { get; set; }

        [Column("numero")]
        [MaxLength(30)]
        [Required]
        public string Numero { get; set; }

        [Column("complemento")]
        [MaxLength(255)]
        [Required]
        public string Complemento { get; set; }

        [Column("cidade")]
        [MaxLength(150)]
        [Required]
        public string Cidade { get; set; }

        [Column("estado")]
        [MaxLength(2)]
        [Required]
        public string Estado { get; set; }
    }
}
