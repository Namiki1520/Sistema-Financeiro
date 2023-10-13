using System;
using Entities.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options ) : base(options)
        {
        }

        public DbSet<SistemaFinanceiro> SistemaFinanceiro { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { set; get; }
        public DbSet<Categoria> Categoria { set; get; }
        public DbSet<Despesa> Despesa { set; get; }
        public DbSet<Receita> Receita { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            //return "Data Source=.\SQLexpress;Initial Catalog=DBfinanceiroupdate;Integrated Security=False;User ID=jairo;Password=Na1mi@ki#;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            return "Data Source=DESKTOP-42UINND\\SQLEXPRESS;Initial Catalog=DBfinanceiroupdate;Integrated Security=True;TrustServerCertificate=true"; // Evitar

            //return "Server=tcp:jairocloud.database.windows.net,1433;Initial Catalog=DBfinanceiroupdate;Persist Security Info=False;User ID=jairo;Password=Na1mi@ki#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; // azure
        }


    }
}
