using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Models.Mappings
{
   internal class CarMapping : IEntityTypeConfiguration<Car>
   {
      public void Configure(EntityTypeBuilder<Car> builder)
      {
         builder.ToTable("cars");
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id).HasColumnName("id").UseMySqlIdentityColumn();
         builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
      }
   }
}
