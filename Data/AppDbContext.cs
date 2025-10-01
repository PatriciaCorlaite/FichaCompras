using FichaCompras.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FichaCompras.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Solicitacao> Solicitacoes { get; set; }
    }
}