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

            builder.HasMany(x => x.Fotos)
                .WithOne()
                .HasConstraintName("FK_Declaracao_Foto")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Depoimento)
                .HasMaxLength(200);

            builder.Property(x => x.NomeDoAutor)             
                .HasMaxLength(150);
        }
    }
}
