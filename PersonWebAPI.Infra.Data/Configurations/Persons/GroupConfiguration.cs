using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Infra.Data.Configurations.Persons
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {

            #region properties

            builder.HasKey(x => x.GroupId);

            builder.Property(x => x.GroupName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(50);

            #endregion properties


            #region relations

            builder.HasMany(g => g.PersonGroups)
                .WithOne(pg => pg.Group);

            #endregion relations

        }
    }
}
