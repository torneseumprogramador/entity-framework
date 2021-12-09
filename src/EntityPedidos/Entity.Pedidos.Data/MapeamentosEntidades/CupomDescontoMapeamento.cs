using Entity.Pedidos.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Pedidos.Data.MapeamentosEntidades
{
    public class CupomDescontoMapeamento : IEntityTypeConfiguration<CupomDesconto>
    {
        public void Configure(EntityTypeBuilder<CupomDesconto> builder)
        {
            builder.ToTable("cupons_descontos");

            builder.HasKey(c => c.CupomDescontoId)
                .HasName("PK_cupons_descontos_id");

            builder.Property(c => c.CupomDescontoId)
                .HasColumnName("cupom_desconto_id")
                .HasColumnType("int");

            builder.Property(c => c.CodigoCupom)
                .HasColumnName("codigo_cupom")
                .HasColumnType("varchar(255)");

            builder.Property(c => c.PercentualDesconto)
                .HasColumnName("percentual_desconto")
                .HasPrecision(12, 2);

            builder.Property(c => c.ValorDesconto)
                .HasColumnName("valor_desconto")
                .HasPrecision(12,2);

            builder.Property(c => c.Quantidade)
                .HasColumnName("quantidade")
                .HasPrecision(6)
                .IsRequired();

            builder.Property(c => c.CriadoEm)
                .HasColumnName("criado_em")
                .HasColumnType("datetime(6)")
                .IsRequired();

            builder.Property(c => c.TipoCupomDesconto)
                .HasColumnName("tipo_cupom_desconto")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(c => c.AplicadoEm)
                .HasColumnName("aplicado_em")
                .HasColumnType("datetime(6)")
                .IsRequired();

            builder.Property(c => c.DataExpiracao)
                .HasColumnName("data_expiracao")
                .HasColumnType("datetime(6)")
                .IsRequired();

            builder.Property(c => c.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(c => c.Aplicado)
                .HasColumnName("aplicado")
                .HasColumnType("tinyint")
                .IsRequired();

            //Opcional já que pedido guarda a chave estrangeira
            // builder.HasMany(c => c.Pedidos)
            //     .WithOne(c => c.CupomDesconto);
        }
    }
}