using System;
using System.Collections.Generic;

namespace FinancialTips.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<Account> Accounts { get; set; }

    }
}