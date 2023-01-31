using System;

namespace FinancialTips.Shared.Domain
{
    public class Account : BaseDomainModel
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public string Status { get; set; }
        public int TipId { get; set; }
        public virtual FinancialTip FinancialTip { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}