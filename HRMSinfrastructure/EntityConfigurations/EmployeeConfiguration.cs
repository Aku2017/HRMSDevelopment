using HRMScore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.EntityConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(e => e.companyProjects).WithMany(p => p.Team);
            builder.HasMany(e => e.ProjectsTeamLead).WithOne(p => p.TeamLead);
            builder.Property(x => x.FirstName)
                .HasMaxLength(50);
            builder.Property(x => x.Surname)
                .HasMaxLength(50);
            builder.Property(x => x.OtherName)
                .HasMaxLength(50);
        }
    }
}
