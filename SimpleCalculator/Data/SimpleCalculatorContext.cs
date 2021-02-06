using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCalculator.Models;

namespace SimpleCalculator.Data
{
    public class SimpleCalculatorContext : DbContext
    {
        public SimpleCalculatorContext (DbContextOptions<SimpleCalculatorContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleCalculator.Models.CalculationModel> CalculationModel { get; set; }
    }
}
