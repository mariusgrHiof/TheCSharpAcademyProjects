using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Data;
using WaterLogger.Models;

namespace WaterLogger.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public WaterLog WaterLog { get; set; }

        public UpdateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int id)
        {
            WaterLog = GetById(id);
            return Page();
        }

        private WaterLog GetById(int id)
        {
            var waterLog = _context.WaterLogs.FirstOrDefault(x => x.Id == id);

            return waterLog;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.WaterLogs.Update(WaterLog);
                _context.SaveChanges();

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fail to update record");
                Console.WriteLine(ex.Message);

                return Page();
            }

        }
    }
}
