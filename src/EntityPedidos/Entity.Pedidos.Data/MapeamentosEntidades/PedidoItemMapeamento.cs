using Entity.Pedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Pedidos.Data.MapeamentosEntidades
{
    public class PedidoItemMapeamento : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("pedidos_itens");

            builder.HasKey(pi => pi.PedidoItemId)
                .HasName("PK_pedidos_itens");

            builder.HasIndex(pi => pi.PedidoId, "IX_pedidos_itens_pedido_id");

            builder.HasIndex(pi => pi.ProdutoId, "IX_pedidos_itens_produto_id");

            builder.Property(pi => pi.PedidoItemId)
                .HasColumnName("pedido_item_id")
                .HasColumnType("int");

            builder.Property(pi => pi.PedidoId)
                .HasColumnName("pedido_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(pi => pi.ProdutoId)
                .HasColumnName("produto_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(pi => pi.NomeProduto)
                .HasColumnName("nome_produto")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(pi => pi.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(pi => pi.ValorUnitario)
                .HasColumnName("valor_unitario")
                .HasPrecision(12, 2);

            builder.HasOne(pi => pi.Pedido)
                .WithMany(p => p.PedidoItens)
                .HasForeignKey(pi => pi.PedidoId)
                .HasConstraintName("FK_pedido_itens_pedidos_pedido_id");
        }
    }
}