using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public enum CalculationMethod
    {
        [Display(Name = "+")]
        Addition,
        [Display(Name = "-")]
        Subtraction,
        [Display(Name = "*")]
        Multiplication,
        [Display(Name = "/")]
        Division
    }
}
