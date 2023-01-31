using FinancialTips.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTips.Server.Configurations.Entities
{
    public class CommunitySeedConfiguration : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> builder)
        {
           builder.HasData(
           new Community
           {
               Id = 1,
               Name = "Investing 101",
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               CreatedBy = "System",
               UpdatedBy = "System"
           },

           new Community
           {
               Id = 2,
               Name = "Budgeting 101",
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               CreatedBy = "System",
               UpdatedBy = "System"
           },

           new Community
           {
               Id = 3,
               Name = "Promo Codes",
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               CreatedBy = "System",
               UpdatedBy = "System"
           },

           new Community
           {
               Id = 4,
               Name = "Saving Hacks",
               DateCreated = DateTime.Now,
               DateUpdated = DateTime.Now,
               CreatedBy = "System",
               UpdatedBy = "System"
           }
           );

        }
    }
}
