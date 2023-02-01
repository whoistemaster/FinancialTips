using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialTips.Shared.Domain
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
    public class Chart : BaseDomainModel
    {
        public string Name { get; set; }
    }
    public class Insight : BaseDomainModel
    {
        public string Name { get; set; }

    }
    public class FinancialPlanning : BaseDomainModel
    {
        public string Name { get; set; }

    }
    public class Blog : BaseDomainModel
    {
        public string Name { get; set; }

    }
    public class Community : BaseDomainModel
    {
        public string Name { get; set; }

    }
    public class FinancialTip : BaseDomainModel
    {
        public int Year { get; set; }
        public int CommunityId { get; set; }
        public virtual Community Community { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int PlanId { get; set; }
        public virtual FinancialPlanning FinancialPlanning { get; set; }
        public int InsightId { get; set; }
        public virtual Insight Insight { get; set; }
        public int ChartId { get; set; }
        public virtual Chart Chart { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}
