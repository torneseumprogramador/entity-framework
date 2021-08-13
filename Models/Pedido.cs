using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity_framework.Models
{
    [Table("pedidos")]
    public class Pedido
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }

        [Column("valor_total")]
        [Required]
        public double ValorTotal { get; set; }

        [Column("data")]
        [Required]
        public DateTime Data { get; set; }

    }
}
