using Jornada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jornada.Infra.Mappings
{
    public class DestinoMap : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.ToTable("Destino");
            builder.HasKey(x => x.Id);

            // 1 x N Relacionamento
            builder.HasMany(x => x.Fotos)
                .WithOne()
                .HasConstraintName("FK_Destino_Foto")
                .OnDelete(DeleteBehavior.Cascade); // Deletar em cascata

            builder.Property(x => x.Meta)
                .HasMaxLength(160);
            
            builder.Property(x => x.TextoDescritivo);

            builder.Property(x => x.Preco)
                .HasPrecision(18, 2) 
                .HasDefaultValue(0.0m); 
        }
    }
}
