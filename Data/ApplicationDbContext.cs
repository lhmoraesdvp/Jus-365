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

        public DbSet<Empresa> Empresa { get; set; } // DbSet para a tabela de Empresa
        public DbSet<Models.JsTreeMenuItem> JsTreeMenuItem { get; set; } // DbSet para a tabela de Empresa

        public DbSet<Models.NodeItem> NodeItem { get; set; } // DbSet para a tabela de Empresa

        public DbSet<Plano> Plano { get; set; } // DbSet para a tabela de planos
        public DbSet<FormRegisterViewModel> FormRegisterViewModel { get; set; } // DbSet para a tabela de planos
        public DbSet<FormularioLogin> FormularioLogin { get; set; } // DbSet para a tabela de planos

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
