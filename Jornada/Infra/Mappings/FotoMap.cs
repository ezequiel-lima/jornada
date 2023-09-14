using Jornada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jornada.Infra.Mappings
{
    public class FotoMap : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("Foto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Url);
        }
    }
}
