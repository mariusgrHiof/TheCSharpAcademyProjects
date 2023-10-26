using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Data;
using WaterLogger.Models;

namespace WaterLogger.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public WaterLog WaterLog { get; set; }

        public DeleteModel(ApplicationDbContext context)
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
            var waterLog = _context.WaterLogs.FirstOrDefault(wl => wl.Id == id);

            return waterLog;
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                var waterLog = _context.WaterLogs.FirstOrDefault(wl => wl.Id == id);
                if (waterLog == null) return NotFound();

                _context.WaterLogs.Remove(waterLog);
                _context.SaveChanges();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail to remove record.");
                Console.WriteLine(ex.Message);

                return Page();
            }

        }
    }
}
