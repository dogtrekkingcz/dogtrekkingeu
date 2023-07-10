namespace QrGenerator.Entities;

public sealed record PaymentQrRequest
{
    public string BankAccount { get; set; }
    
    public string Price { get; set; }
    
    public string VariableSymbol { get; set; }
    
    public string Currency { get; set; }
    
    public string Note { get; set; }
}