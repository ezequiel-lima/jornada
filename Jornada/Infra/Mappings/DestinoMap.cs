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

            builder.Property(x => x.Foto);

            builder.Property(x => x.Nome)
                .HasMaxLength(200);

            builder.Property(x => x.Preco)
                .HasPrecision(18, 2) 
                .HasDefaultValue(0.0m); 
        }
    }
}
