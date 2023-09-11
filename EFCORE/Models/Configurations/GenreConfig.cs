using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCORE.Models.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(e => e.GenreId);
            //builder.Property(t=>t.Name).HasMaxLength(150);
            var scifi = new Genre() {GenreId=5, Name="Science fiction" };
            var animation = new Genre() { GenreId = 6, Name = "Animation" };
            builder.HasData(scifi,animation);

            builder.HasIndex(p=>p.Name).IsUnique();
        }
    }
}
