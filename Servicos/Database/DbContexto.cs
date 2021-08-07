using System;
using entity_framework.Models;
using Microsoft.EntityFrameworkCore;

namespace entity_framework.Servicos.Database
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        
        public DbSet<Cliente> Clientes { get; set; }
    }
}