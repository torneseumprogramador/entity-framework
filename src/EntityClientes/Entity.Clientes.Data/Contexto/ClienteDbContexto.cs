using System;
using System.Threading.Tasks;
using Entity.Clientes.Data.MapeamentoEntidades;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#nullable disable

namespace Entity.Clientes.Data.Contexto
{
    public partial class ClienteDbContexto : DbContext, IUnitOfWork
    {
        public ClienteDbContexto()
        {
        }

        public ClienteDbContexto(DbContextOptions<ClienteDbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=EntityFrameworkComunidade;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"))
                .EnableSensitiveDataLogging()
                  .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            }

            optionsBuilder.EnableSensitiveDataLogging()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfiguration<Cliente>(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration<Endereco>(new EnderecoMapeamento());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
