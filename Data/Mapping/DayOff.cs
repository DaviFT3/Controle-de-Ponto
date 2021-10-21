using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class DayOffMap : IEntityTypeConfiguration<DayOff>
    {
        public void Configure(EntityTypeBuilder<DayOff> builder)
        {
            builder.ToTable("DayOffs");

            builder.HasKey(prop => prop.Id);

        }
    }
}
