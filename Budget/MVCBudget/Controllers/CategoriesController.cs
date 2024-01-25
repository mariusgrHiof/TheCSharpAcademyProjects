using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBudget.Data;
using MVCBudget.Dtos;

namespace MVCBudget.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly BudgetContext _context;

    public CategoriesController(BudgetContext context)
    {
        _context = context;
    }

    [HttpGet("GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        var categoriesDtos = categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
        });
        return Ok(categoriesDtos);
    }
}
