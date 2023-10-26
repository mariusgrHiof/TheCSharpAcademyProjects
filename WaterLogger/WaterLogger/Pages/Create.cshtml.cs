using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Data;
using WaterLogger.Models;

namespace WaterLogger.Pages;
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public CreateModel(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public WaterLog WaterLog { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        WaterLog = new WaterLog()
        {
            Date = WaterLog.Date,
            Quantity = WaterLog.Quantity,
        };

        try
        {
            _context.WaterLogs.Add(WaterLog);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fail to add record.");
            Console.WriteLine(ex.Message);
            return Page();
        }


    }
}

