﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class CalculationModel
    {
        public int ID { get; set; }

        [Display(Name = "First Number")]
        public double Number1 { get; set;}

    
        [Display(Name ="Second Number")]
        public double Number2 { get; set; }

        [Display(Name = "")]
        public CalculationMethod CalculationMethod { get; set; }

        [NotDivideByZero]
        public double Result { get; set; }


    }
}
