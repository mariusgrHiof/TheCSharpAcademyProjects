namespace MVCBudget.Dtos;

public class CreateTransactionDto
{

    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Decimal Amount { get; set; }
    public int CategoryId { get; set; }
}
