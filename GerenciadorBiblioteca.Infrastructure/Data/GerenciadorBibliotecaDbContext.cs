using GerenciadorBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System;

namespace GerenciadorBiblioteca.Infrastructure.Data
{
    public class GerenciadorBibliotecaDbContext : DbContext
    {
        public GerenciadorBibliotecaDbContext(DbContextOptions<GerenciadorBibliotecaDbContext> options) : base(options)
        {

        }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GerenciadorBibliotecaDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
