using System.ComponentModel.DataAnnotations;

namespace eshop_backend.Models
{
    public class ExpiryYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int currentYear = DateTime.Now.Year;
            if ((int)value >= currentYear && (int)value <= currentYear + 4)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Expiration year is out of range (" + currentYear + "-" + currentYear + 4 + ")");
        }
    }
}
