using FinancialTips.Server.Data;
using FinancialTips.Server.IRepository;
using FinancialTips.Server.Models;
using FinancialTips.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinancialTips.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Account> _accounts;
        private IGenericRepository<User> _users;
        private IGenericRepository<Insight> _insights;
        private IGenericRepository<Blog> _blogs;
        private IGenericRepository<Chart> _charts;
        private IGenericRepository<Community> _community;
        private IGenericRepository<FinancialPlanning> _financialplannings;
        private IGenericRepository<FinancialTip> _financialtip;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Account> Accounts
            => _accounts ??= new GenericRepository<Account>(_context);
        public IGenericRepository<User> Users
            => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<Insight> Insights
            => _insights ??= new GenericRepository<Insight>(_context);
        public IGenericRepository<Blog> Blogs
            => _blogs ??= new GenericRepository<Blog>(_context);
        public IGenericRepository<Chart> Charts
            => _charts ??= new GenericRepository<Chart>(_context);
        public IGenericRepository<Community> Communities
            => _community ??= new GenericRepository<Community>(_context);
        public IGenericRepository<FinancialPlanning> FinancialPlannings
            => _financialplannings ??= new GenericRepository<FinancialPlanning>(_context);
        public IGenericRepository<FinancialTip> FinancialTip
            => _financialtip ??= new GenericRepository<FinancialTip>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}