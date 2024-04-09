namespace PetsOnTrail.Interfaces.Actions.Entities.Actions;

public sealed record AcceptPaymentRequest
{
    public Guid Id { get; set; }
    
    public Guid ActionId { get; set; }
    
    public double Amount { get; set; }
    
    public string Currency { get; set; }
    
    public string Note { get; set; }
    
    public string BankAccount { get; set; }
}