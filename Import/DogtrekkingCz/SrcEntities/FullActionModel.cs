namespace Import.DogtrekkingCz.SrcEntities;

internal sealed record FullActionModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? Begin { get; set; }
    public DateTimeOffset? End { get; set; }

    public AddressDto Address { get; set; }
    
    public string ContactMail { get; set; }
    
    public string Phone { get; set; }

    public bool IsHidden { get; set; }
    public bool IsCanceled { get; set; }

    public string CancelledReason { get; set; }

    public IList<RaceDto> Races { get; set; }

    public IList<TShirtOfferDto> TShirts { get; set; } = new List<TShirtOfferDto>();
    

    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
    }

    public class TShirtOfferDto
    {
        public Guid Id { get; set; }

        public int OldId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public double Price { get; set; } = 0.0;

        public string Currency { get; set; } = "Kč";

        public List<string> Variants { get; set; } = new List<string>();

        public List<string> Sizes { get; set; } = new List<string>();

        public List<string> Colors { get; set; } = new List<string>();
    }
    
    public class RaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Distance { get; set; }
        public double? Incline { get; set; }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public List<PaymentDefinitionDto> PaymentDefinitions { get; set; } = new List<PaymentDefinitionDto>();
    }
    
    public class PaymentDefinitionDto
    {
        public Guid Id { get; set; } = default(Guid);
        
        public string BankAccount { get; set; }
            
        public DateTimeOffset From { get; set; }
            
        public DateTimeOffset To { get; set; }
            
        public double Price { get; set; }

        public string Currency { get; set; } = "Kc";
    }

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<RacerDto> Racers { get; set; }
    }

    public class RacerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public DateTimeOffset? Birthday { get; set; }


        public List<DogDto> Dogs { get; set; }

        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? Finish { get; set; }

        public IList<CheckpointDto> Checkpoints { get; set; }

        public RaceState State { get; set; }

        public DateTimeOffset? Received { get; set; }
        public DateTimeOffset? Payed { get; set; }

        public List<(DateTimeOffset, string)> Notes { get; set; }

        public List<TShirtOrder> TShirtOrders { get; set; } = new List<TShirtOrder>();

        public List<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
    
    public class PaymentDto
    {
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

        public double Amount { get; set; } = 0.0;

        public string Currency { get; set; } = "Kč";

        public string BankAccount { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }

    public class TShirtOrder
    {
        public Guid Id { get; set; }

        public Guid OfferId { get; set; }

        public string Size { get; set; }
        
        public double Count { get; set; }
        
        public double Price { get; set; }
        
        public string Color { get; set; }
    }

    public class DogDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Pedigree { get; set; }
        public string Chip { get; set; }
    }

    public class CheckpointDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset Passed { get; set; }
    }

    public enum RaceState
    {
        NotStarted = 0,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }
}