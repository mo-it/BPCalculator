using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BPCalculator.Pages
{
    public class BloodPressureModel : PageModel
    {
        [BindProperty]
        public BloodPressure BP { get; set; } = new(); // null-safe

        public void OnGet()
        {
            // Optional: default values for quick demo
            BP = new BloodPressure
            {
                Systolic = 100,
                Diastolic = 60
            };
        }

        public IActionResult OnPost()
        {
            // DataAnnotations validation (Range, etc.)
            if (!ModelState.IsValid)
                return Page();

            // Cross-field validation
            if (BP.Systolic <= BP.Diastolic)
            {
                ModelState.AddModelError(
                    "BP.Systolic",
                    "Systolic must be greater than Diastolic"
                );

                return Page();
            }

            return Page();
        }
    }
}
