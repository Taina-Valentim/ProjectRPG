using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Data
{
    public class RPGDbContext : IdentityDbContext<IdentityUser>
    {
        public RPGDbContext(DbContextOptions<RPGDbContext> opcoes) : base(opcoes)
        { }

        #region DbSet

        public DbSet<Armamento> Armas { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<Condicao> Condicoes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<RPGUser> RPGUsers { get; set; }

        #endregion


        #region ModelBuilder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
