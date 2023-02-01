using FinancialTips.Server.Configurations.Entities;
using FinancialTips.Server.Models;
using FinancialTips.Shared.Domain;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTips.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Tip> Tips { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Insight> Insights { get; set; }
        public DbSet<FinancialPlanning> FinancialPlannings { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Community> Communitys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BlogSeedConfiguration());
            builder.ApplyConfiguration(new ChartSeedConfiguration());
            builder.ApplyConfiguration(new CommunitySeedConfiguration());
            builder.ApplyConfiguration(new FinancialPlanningSeedConfiguration());
            builder.ApplyConfiguration(new InsightSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());


        }
    }
}
