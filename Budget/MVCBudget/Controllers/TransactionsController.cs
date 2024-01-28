using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBudget.Data;
using MVCBudget.Dtos;
using MVCBudget.Models;

namespace MVCBudget.mariusgrHiof.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly BudgetContext _context;

    public TransactionsController(BudgetContext context)
    {
        _context = context;
    }

    [HttpGet]
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
        if (transaction is null)
        {
            return NotFound();
        }

        var transactionDto = new TransactionDto
        {
            Name = transaction.Name,
            Id = transaction.Id,
            Date = transaction.Date,
            Amount = transaction.Amount,
            CategoryDto = new CategoryDto
            {
                Id = transaction.Category.Id,
                Name = transaction.Category.Name,
            }
        };

        return Ok(transactionDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionDto newTransaction)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == newTransaction.CategoryId);
        if (category is null) return BadRequest("Category not found");

        var transaction = new Transaction
        {
            Name = newTransaction.Name,
            Amount = newTransaction.Amount,
            Date = newTransaction.Date,
            CategoryId = category.Id,

        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        var transactionDto = new TransactionDto
        {
            Id = transaction.Id,
            Name = transaction.Name,
            Date = transaction.Date,
            Amount = transaction.Amount,
            CategoryDto = new CategoryDto
            {
                Id = transaction.Category.Id,
                Name = transaction.Category.Name,
            }

        };

        return CreatedAtAction(nameof(GetTransaction), new { id = transactionDto.Id }, transactionDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTransaction([FromBody] Transaction transaction)
    {
        _context.Transactions.Update(transaction);

        await _context.SaveChangesAsync();

        return NoContent();

    }


}
