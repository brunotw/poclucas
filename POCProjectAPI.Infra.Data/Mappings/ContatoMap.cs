using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCProjectAPI.Domain.Models;

namespace POCProjectAPI.Infra.Data.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.ContatoId);

            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Conteudo).IsRequired().HasColumnType("varchar(80)");

            builder.HasOne(x => x.Pessoa)
                .WithMany(i => i.Contatos)
                .HasForeignKey(x => x.PessoaId);

            builder.ToTable("POCAPI_Contatos");
        }
    }
}