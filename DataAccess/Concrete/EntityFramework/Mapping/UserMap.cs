using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users",@"dbo");
            builder.HasKey(x=> x.Id);

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FirstName)
               .HasColumnName("FirstName")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.LastName)
               .HasColumnName("LastName")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Password)
              .HasColumnName("Password")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(x => x.Gender)
             .HasColumnName("Gender")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(x => x.DateOfBirth)
            .HasColumnName("DateOfBirth")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasData(new User
            {
                Id=1,
                UserName="svvlacet",
                FirstName = "Şevval",
                LastName = "Acet",
                Password = "1234",
                Gender = true,
                DateOfBirth=Convert.ToDateTime("06-09-2001"),
                CreatedDate=DateTime.Now,
                Address="Lüleburgaz",
                CreatedUserId=1,
                Email="sevvalacet@gmail.com"
            });
        }
    }
}
