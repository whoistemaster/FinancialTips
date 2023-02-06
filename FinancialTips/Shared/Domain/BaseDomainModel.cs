using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Name { get; set; }
    }
    public class Insight : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }

    }
    public class FinancialPlanning : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }

    }
    public class Blog : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }

    }
    public class Community : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }

    }
    public class Tip : BaseDomainModel
    {
        [Required]
        public int Year { get; set; }

        [Required]
        public int? CommunityId { get; set; }
        public virtual Community Community { get; set; }

        [Required]
        public int? BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        [Required]
        public int? FinancialPlanningId { get; set; }
        public virtual FinancialPlanning FinancialPlanning { get; set; }

        [Required]
        public int? InsightId { get; set; }
        public virtual Insight Insight { get; set; }

        [Required]
        public int? ChartId { get; set; }
        public virtual Chart Chart { get; set; }
        public virtual List<Account> Accounts { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double RentalRate { get; set; }
    }
}
