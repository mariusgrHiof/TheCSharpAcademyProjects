using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterLogger.Data;
using WaterLogger.Models;

namespace WaterLogger.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public List<WaterLog> WaterLogs { get; set; }

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        WaterLogs = GetWaterlogs();
    }

    private List<WaterLog> GetWaterlogs()
    {
        return _context.WaterLogs.ToList();
    }
}
