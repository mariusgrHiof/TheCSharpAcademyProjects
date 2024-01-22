namespace MVCBudget.Dtos;

public class TransactionDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public DateTime Date { get; set; }
  public Decimal Amount { get; set; }
  public CategoryDto CategoryDto { get; set; }
}
