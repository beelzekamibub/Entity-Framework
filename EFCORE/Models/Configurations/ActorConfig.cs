using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCORE.Models.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //builder.Property(t => t.Name).HasMaxLength(150);
            builder.Property(t => t.DateOfBirth).HasColumnType("date");
            builder.Property(t => t.Fortune).HasPrecision(18, 2);
        }
    }
}
