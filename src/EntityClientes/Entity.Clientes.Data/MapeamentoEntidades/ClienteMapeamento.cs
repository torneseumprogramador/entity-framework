using Entity.Clientes.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Clientes.Data.MapeamentoEntidades
{
    public class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();
            
            builder.Property(x => x.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(200)");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("datetime(6)");

            builder.Property(x => x.EnderecoId)
                .HasColumnName("endereco_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.Endereco)
                .WithMany(x => x.Clientes)
                .HasForeignKey(x => x.EnderecoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}