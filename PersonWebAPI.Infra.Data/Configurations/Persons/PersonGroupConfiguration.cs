using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PersonWebAPI.Infra.Data.Configurations.Persons
{
    public class PersonGroupConfiguration : IEntityTypeConfiguration<PersonGroup>
    {
        public void Configure(EntityTypeBuilder<PersonGroup> builder)
        {

            #region properties


            builder.HasKey(p => new { p.PersonId, p.GroupId });

            #endregion properties


            #region relations

            builder.HasOne(pg => pg.Person)
                  .WithMany(p => p.PersonGroups)
                  .HasForeignKey(pg => pg.PersonId);


            builder.HasOne(pg => pg.Group)
                 .WithMany(p => p.PersonGroups)
                 .HasForeignKey(pg => pg.GroupId);


            #endregion relations
        }
    }
}
