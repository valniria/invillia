using Dominio.Contextos.Jogos;
using Dominio.Contextos.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracao
{
    public class ContextoBase : DbContext
    {
        public ContextoBase(DbContextOptions<ContextoBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #region Tabelas
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConnetionConfig());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConnetionConfig()
        {
            string strCon = "Server=127.0.0.1,1433;Database=DB_JOGOS;User Id=sa;Password=myStrong(!)Password;"; //falta ainda ajustar isso.
            return strCon;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
