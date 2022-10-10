using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCProjectAPI.Domain.Models;

namespace POCProjectAPI.Infra.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.PessoaId);

            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Idade);
            builder.Property(x => x.Sexo).HasColumnType("varchar(9)");

            builder.ToTable("POCAPI_Pessoas");
        }
    }
}