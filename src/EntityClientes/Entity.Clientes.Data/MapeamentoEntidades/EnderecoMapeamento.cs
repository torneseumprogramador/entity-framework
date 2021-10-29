using Entity.Clientes.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Clientes.Data.MapeamentoEntidades
{
    public class EnderecoMapeamento : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");

            builder.HasKey(e => e.Id);

             builder.HasIndex(e => e.Id, "IX_enderecos_id");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(e => e.Logradouro)
                .HasColumnName("logradouro")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("cep")
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("varchar(150)")
                .IsRequired();
            
            builder.Property(e => e.Numero)
                .HasColumnName("numero")
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("complemento")
                .HasColumnType("varchar(255)")
                .IsRequired();
            
            builder.Property(e => e.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(2)")
                .IsRequired();

            //Relacionamento opcional
            builder.HasMany(e => e.Clientes)
                .WithOne(c => c.Endereco)
                .HasForeignKey(c => c.EnderecoId)
                .HasConstraintName("FK_clientes_enderecos_enderecoid");
        }
    }
}