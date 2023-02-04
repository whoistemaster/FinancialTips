using System;

namespace FinancialTips.Shared.Domain
{
    public class Account : BaseDomainModel
    {
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Password { get; set; }
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}