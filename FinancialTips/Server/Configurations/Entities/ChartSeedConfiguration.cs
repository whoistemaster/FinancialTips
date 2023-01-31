using FinancialTips.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTips.Server.Configurations.Entities
{
    public class ChartSeedConfiguration : IEntityTypeConfiguration<Chart>
    {
        public void Configure(EntityTypeBuilder<Chart> builder)
        {
            builder.HasData(
           new Chart
           {
               Id = 1,
               Name = "Monthly Savings",
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               CreatedBy = "System",
               UpdatedBy = "System"
           },

           new Chart
           {
               Id = 2,
               Name = "Yearly Savings",
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               CreatedBy = "System",
               UpdatedBy = "System"
           }
           );

        }
    }
}
