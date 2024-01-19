namespace MVCBudget.mariusgrHiof.Models;

public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Decimal Amount { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
