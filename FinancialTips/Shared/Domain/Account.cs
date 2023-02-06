using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FinancialTips.Shared.Domain
{
    public class Account : BaseDomainModel, IValidatableObject
    {
        public DateTime? DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Password { get; set; }
        public int TipId { get; set; }
        public virtual Tip Tip { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();

            if (DateIn != null)
            {
                if (DateIn <= DateOut)
                {
                    yield return new ValidationResult("DateIn must be greater than DateOut", new[] { "DateIn" });

                }
            }
        }
    }
}
        
            


