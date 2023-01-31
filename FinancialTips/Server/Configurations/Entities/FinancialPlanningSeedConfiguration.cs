using FinancialTips.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTips.Server.Configurations.Entities
{
    public class FinancialPlanningSeedConfiguration : IEntityTypeConfiguration<FinancialPlanning>
    {
        public void Configure(EntityTypeBuilder<FinancialPlanning> builder)
        {
            builder.HasData(
            new FinancialPlanning
            {
                Id = 1,
                Name = "Budget",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            new FinancialPlanning
            {
                Id = 2,
                Name = "Medisave",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            new FinancialPlanning
            {
                Id = 3,
                Name = "Insurance",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            new FinancialPlanning
            {
                Id = 4,
                Name = "Property",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            new FinancialPlanning
            {
                 Id = 5,
                 Name = "Tax",
                 DateCreated = DateTime.Now,
                 DateUpdated = DateTime.Now,
                 CreatedBy = "System",
                 UpdatedBy = "System"
            },

            new FinancialPlanning
            {
                Id = 6,
                Name = "Student Loan",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },

            new FinancialPlanning
            {
                Id = 7,
                Name = "CPF",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            }
            );

        }
    }
}
