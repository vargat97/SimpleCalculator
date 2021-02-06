using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    // Class for validating the result!
    // [NotDivideByZero] Data Annotation above the Model.Result. 
    // If the divider is 0, print an ErrorMessage!
    public class NotDivideByZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CalculationModel c = (CalculationModel)validationContext.ObjectInstance;

            if(c.Number2 == 0 && c.CalculationMethod == CalculationMethod.Division)
            {
                return new ValidationResult("Divided by 0! Can't calculate it!");
            }

            return ValidationResult.Success;

        }
    }
}
