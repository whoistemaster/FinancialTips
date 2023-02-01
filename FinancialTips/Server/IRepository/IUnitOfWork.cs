using FinancialTips.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTips.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Account> Accounts { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Insight> Insights { get; }
        IGenericRepository<Blog> Blogs { get; }
        IGenericRepository<Community> Community { get; }
        IGenericRepository<Chart> Charts { get; }
        IGenericRepository<FinancialPlanning> FinancialPlannings { get; }
        IGenericRepository<Tip> Tips { get; }
    }
}