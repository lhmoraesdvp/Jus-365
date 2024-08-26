using Jus_365.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;


namespace Jus_365.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Plano> Planos { get; set; } // DbSet para a tabela de planos
        public DbSet<Empresa> Empresa { get; set; } // DbSet para a tabela de Empresa

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Plano>()
            //    .HasOne(p => p.)
            //    .WithMany()  // Se o relacionamento for 1:N, você pode usar WithMany(r => r.Planos)
            //    .HasForeignKey(p => p.Role)
            //    .OnDelete(DeleteBehavior.Restrict); // Define OnDelete como Restrict
        }
        
    }
}
