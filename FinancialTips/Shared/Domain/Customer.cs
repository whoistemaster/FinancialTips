using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialTips.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "First Name does not meet length requirements")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Last Name does not meet length requirements")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Proper Gender")]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string Contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        
        public string EmailAddress { get; set; }
        public virtual List<Account> Accounts { get; set; }

    }
}