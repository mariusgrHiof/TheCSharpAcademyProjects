using Microsoft.EntityFrameworkCore;
using MVCBudget.Data;

var builder = WebApplication.CreateBuilder(args);

// Add db context
builder.Services.AddDbContext<BudgetContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetDb"));
});

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();


// Add default files
app.UseDefaultFiles();

// Add static files
app.UseStaticFiles();

// Add controllers
app.MapControllers();


app.Run();
