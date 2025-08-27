using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonWebAPI.Infra.Data.Configurations.Persons
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            #region properties

            builder.HasKey(p => p.PersonID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Mobile)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(11);

            builder.Property(p => p.City)
                .HasMaxLength(100);

            builder.Property(p => p.Address)
                .HasMaxLength(250);

            builder.Property(p => p.Email)
                .HasMaxLength(100);

            builder.Property(p => p.Age)
                .HasColumnType("integer");

            #endregion properties


            #region relations

            builder.HasMany(p => p.PersonGroups)
              .WithOne(pg => pg.Person);

            builder.HasMany(p => p.Vouchers)
                .WithOne(v => v.Person)
                .HasForeignKey("PersonId")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion relations

        }

    }
}

