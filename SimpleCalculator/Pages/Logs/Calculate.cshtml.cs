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

           // ModelState.Remove("Result");
            //return RedirectToPage("./Logs/Create");
            return Page();
        }


            private double CalculateResult()
        {
            double result;
            switch (CalculationModel.CalculationMethod)
            {
                case CalculationMethod.Addition:
                    result = CalculationModel.Number1 + CalculationModel.Number2;
                    break;
                case CalculationMethod.Subtraction:
                    result = CalculationModel.Number1 - CalculationModel.Number2;
                    break;
                case CalculationMethod.Multiplication:
                    result = CalculationModel.Number1 * CalculationModel.Number2;
                    break;
                case CalculationMethod.Division:
                    result = CalculationModel.Number1 / CalculationModel.Number2;
                    break;

                default:
                    result = 0;
                    break;
            }
            return result;
        }
    }
}
