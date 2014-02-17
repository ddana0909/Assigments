using System;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.HelperClasses
{
    public class DataRange: ValidationAttribute
    {
        private readonly DateTime _todaysDate;

        public DataRange() : base("{0} is not allowed to be priour to todays Date")
        {
            _todaysDate = DateTime.Now;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var inputDate =(DateTime)value;
                if (DateTime.Compare(inputDate, _todaysDate) <= 0)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
        
    }
}