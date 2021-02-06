using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCalculator.Data;
using SimpleCalculator.Models;

namespace SimpleCalculator.Pages.Logs
{
    public class CreateModel : PageModel
    {
        private readonly SimpleCalculator.Data.SimpleCalculatorContext _context;

        public CreateModel(SimpleCalculator.Data.SimpleCalculatorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            this.calculationModel = new CalculationModel();
            return Page();
        }

        private CalculationModel calculationModel;

        // Modified property, bc of the set branch
        // It has to calculate the Result, before the db operation.
        // --> that means, if the datas not valid, datas will not logged into db
        [BindProperty]
        public CalculationModel CalculationModel {
            get {
                return this.calculationModel;
            }
            set {
                calculationModel = value;
                calculationModel.Result = this.CalculateResult();
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.CalculationModel.Add(CalculationModel);
            await _context.SaveChangesAsync();

            return Page();
        }


            private double CalculateResult()
        {
            var result = CalculationModel.CalculationMethod switch
            {
                CalculationMethod.Addition => CalculationModel.Number1 + CalculationModel.Number2,
                CalculationMethod.Subtraction => CalculationModel.Number1 - CalculationModel.Number2,
                CalculationMethod.Multiplication => CalculationModel.Number1 * CalculationModel.Number2,
                CalculationMethod.Division => CalculationModel.Number1 / CalculationModel.Number2,
                _ => 0,
            };
            return result;
        }
    }
}
