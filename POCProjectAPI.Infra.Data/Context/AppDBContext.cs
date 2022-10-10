using Microsoft.EntityFrameworkCore;
using POCProjectAPI.Domain.Models;
using POCProjectAPI.Infra.Data.Mappings;

namespace POCProjectAPI.Infra.Data.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Impede que propriedades não mapeadas com limite de tamanho sejam criadas com o tamanho varchar MAX
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            new PessoaMap().Configure(modelBuilder.Entity<Pessoa>());
            new ContatoMap().Configure(modelBuilder.Entity<Contato>());
        }
    }
}