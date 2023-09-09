using Jornada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jornada.Infra.Mappings
{
    public class DeclaracaoMap : IEntityTypeConfiguration<Declaracao>
    {
        public void Configure(EntityTypeBuilder<Declaracao> builder)
        {
            builder.ToTable("Declaracao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Foto);

            builder.Property(x => x.Depoimento)
                .HasMaxLength(200);

            builder.Property(x => x.NomeDoAutor)             
                .HasMaxLength(150);
        }
    }
}
