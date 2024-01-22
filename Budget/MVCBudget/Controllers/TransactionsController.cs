using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBudget.Data;
using MVCBudget.Dtos;

namespace MVCBudget.mariusgrHiof.Controllers;

[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
  private readonly BudgetContext _context;

  public TransactionsController(BudgetContext context)
  {
    _context = context;
  }
  [HttpGet("GetTransactions")]
  public async Task<IActionResult> GetTransactions()
  {
    var transactions = await _context.Transactions
        .Include(t => t.Category)
        .ToListAsync();

    List<TransactionDto> transactionsDto = new List<TransactionDto>();

    foreach (var transaction in transactions)
    {
      transactionsDto.Add(new TransactionDto
      {
        Id = transaction.Id,
        Name = transaction.Name,
        Amount = transaction.Amount,
        CategoryDto = new CategoryDto
        {
          Id = transaction.Category.Id,
          Name = transaction.Category.Name,
          Description = transaction.Category.Description
        },
        Date = transaction.Date,
      });
    }

    return Ok(transactionsDto);
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

    return Ok(transaction);
  }
}
