using Microsoft.EntityFrameworkCore;
using Entity.Pedidos.Domain.Entidades;
using Entity.Pedidos.Domain.Repositories;
using System.Threading.Tasks;

#nullable disable

namespace Entity.Pedidos.Data.Contexto
{
    public partial class PedidosDbContexto : DbContext, IUnitOfWork
    {
        public PedidosDbContexto()
        {
        }

        public PedidosDbContexto(DbContextOptions<PedidosDbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }
        public virtual DbSet<CupomDesconto> CupomDescontos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=EntityFrameworkComunidade;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosDbContexto).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}
