using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class NotDivideByZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CalculationModel c = (CalculationModel)validationContext.ObjectInstance;
            if(c.Number2 == 0 && c.CalculationMethod == CalculationMethod.Division)
                return new ValidationResult("Divided by 0");

            return ValidationResult.Success;

        }
    }
}
