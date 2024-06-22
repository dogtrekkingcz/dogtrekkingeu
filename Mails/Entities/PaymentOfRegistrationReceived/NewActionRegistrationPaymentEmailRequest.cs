namespace Mails.Entities.PaymentOfRegistrationReceived;

public record NewActionRegistrationPaymentEmailRequest
{
    public ActionDto Action { get; set; } = new();

    public RacerDto Racer { get; set; } = new();

    public Dictionary<TermDto, PaymentDto> Payments { get; set; } = new();

    public List<ReceivedPaymentDto> ReceivedPayments { get; set; } = new();

    public double Amount { get; set; } = double.NaN;

    public string Currency { get; set; } = string.Empty;
    

    public sealed record ActionDto
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
    }

    public sealed record RacerDto
    {
        public Guid Id { get; set; }
        
        public DateTimeOffset Created { get; set; }
        
        public string LanguageCode { get; set; } = "en-US";

        public Guid UserId { get; set; } = Guid.Empty;

        public Guid CompetitorId { get; set; } = Guid.Empty;

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
    }

    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; }
        
        public DateTimeOffset To { get; set; }
    }

    public sealed record PaymentDto
    {
        public string BankAccount { get; set; }
        
        public DateTimeOffset From { get; set; }
        
        public DateTimeOffset To { get; set; }
        
        public double Price { get; set; }
        
        public string Currency { get; set; }
    }

    public sealed record ReceivedPaymentDto
    {
        public DateTimeOffset Received { get; set; }
        
        public double Amount { get; set; }
        
        public string Currency { get; set; }
    }
}