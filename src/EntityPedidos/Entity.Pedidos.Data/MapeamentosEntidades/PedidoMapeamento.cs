using Entity.Pedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Pedidos.Data.MapeamentosEntidades
{
    public class PedidoMapeamento : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedidos");

            builder.HasKey(p => p.Id)
                .HasName("PK_pedidos");

            builder.HasIndex(p => p.ClienteId, "IX_pedidos_cliente_id");

            builder.HasIndex(p => p.CupomDescontoId, "IX_pedido_cupom_desconto_id");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(p => p.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("varchar(150)");

            builder.Property(p => p.ClienteId)
                .HasColumnName("cliente_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.EnderecoId)
                .HasColumnName("endereco_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Desconto)
                .HasColumnName("desconto")
                .HasPrecision(12, 2);

            builder.Property(p => p.ValorTotal)
                .HasColumnName("valor_total")
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(p => p.Data)
                .HasColumnName("data_pedido")
                .HasColumnType("datetime(6)")
                .IsRequired();

            builder.Property(p => p.PedidoStatus)
                .HasColumnName("pedido_status")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.CupomDescontoId)
                .HasColumnName("cupom_desconto_id")
                .HasColumnType("int");

            builder.HasOne(p => p.CupomDesconto)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.CupomDescontoId)
                .HasConstraintName("FK_pedidos_cupons_descontos_cupom_desconto_id");

            builder.HasOne(p => p.Endereco)
                .WithMany(e => e.Pedidos)
                .HasForeignKey(p => p.EnderecoId)
                .HasConstraintName("FK_pedidos_enderecos_endereco_id");

            //Definição opcional pois pedido item guarda a foreign key
            builder.HasMany(p => p.PedidoItens)
                .WithOne(pi => pi.Pedido)
                .HasForeignKey(pi => pi.PedidoId)
                .HasConstraintName("FK_pedido_itens_pedidos_pedido_id");
        
        }
    }
}