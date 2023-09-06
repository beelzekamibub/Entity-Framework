using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCORE.Models.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //builder.Property(t => t.Title).HasMaxLength(150);
            builder.Property(t => t.ReleaseDate).HasColumnType("date");
        }
    }
}