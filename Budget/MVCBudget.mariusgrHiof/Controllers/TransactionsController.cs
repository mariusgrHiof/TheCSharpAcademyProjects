using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBudget.mariusgrHiof.Data;

namespace MVCBudget.mariusgrHiof.Controllers;

public class TransactionsController : Controller
{
    private readonly BudgetContext _context;

    public TransactionsController(BudgetContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var transactions = await _context.Transactions
            .Include(t => t.Category)
            .ToListAsync();
        return View(transactions);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransaction(int id)
    {
        var transaction = await _context
            .Transactions
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (transaction == null)
        {
            return NotFound();
        }

        return View(transaction);
    }
}
