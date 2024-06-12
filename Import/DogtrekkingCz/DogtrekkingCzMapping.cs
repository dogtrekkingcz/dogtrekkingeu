using Import.DogtrekkingCz.SrcEntities;
using Mapster;
using Storage.Entities.Actions;

namespace Import.DogtrekkingCz;

internal static class DogtrekkingCzMapping
{
    internal static TypeAdapterConfig AddDogtrekkingCzMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<FullActionModel, CreateActionInternalStorageRequest>()
            .MapWith(s => new CreateActionInternalStorageRequest
            {
                Id = s.Id,
                Name = s.Name,
                Created = DateTimeOffset.Now,
                Term = new CreateActionInternalStorageRequest.TermDto
                {
                    From = s.Begin ?? DateTimeOffset.Now,
                    To = s.End ?? DateTimeOffset.Now
                },
                Address = new CreateActionInternalStorageRequest.AddressDto
                {
                    City = s.Address.City,
                    Country = "Czech Republic",
                    Position = new CreateActionInternalStorageRequest.LatLngDto
                    {
                        Latitude = s.Address.GpsLatitude ?? double.NaN,
                        Longitude = s.Address.GpsLongitude ?? double.NaN
                    },
                    Region = string.Empty,
                    Street = s.Address.Street,
                    ZipCode = string.Empty
                },
                Description = s.Description ?? string.Empty,
                TypeId = Guid.Empty,
                ContactMail = s.ContactMail ?? string.Empty,
                Checkpoints = new List<CreateActionInternalStorageRequest.CheckpointDto>(),
                Sale = new CreateActionInternalStorageRequest.ActionSaleDto
                {
                    Items = s.TShirts.Select(tshirt => new CreateActionInternalStorageRequest.ActionSaleItemDto
                        {
                            Id = tshirt.Id.ToString(),
                            Description = tshirt.Description,
                            Currency = tshirt.Currency,
                            Price = tshirt.Price,
                            Name = tshirt.Name,
                            Colors = tshirt.Colors,
                            Sizes = tshirt.Sizes,
                            Variants = tshirt.Variants
                        })
                        .ToList()
                },
                Races = s.Races.Select(race => new CreateActionInternalStorageRequest.RaceDto
                    {
                        Begin = s.Begin ?? DateTimeOffset.Now,
                        Name = string.IsNullOrEmpty(race.Name) ? s.Name : race.Name,
                        Id = race.Id,
                        Distance = race.Distance,
                        Incline = race.Incline,
                        Limits = new(),
                        EnteringFrom = DateTimeOffset.MinValue,
                        EnteringTo = DateTimeOffset.MinValue,
                        MaxNumberOfCompetitors = int.MaxValue,
                        Categories = race.Categories.Select(ctg => new CreateActionInternalStorageRequest.CategoryDto
                        {
                            Id = ctg.Id,
                            Name = ctg.Name,
                            Racers = ctg.Racers.Select(racer => new CreateActionInternalStorageRequest.RacerDto
                            {
                                Id = racer.Id,
                                Address = new CreateActionInternalStorageRequest.AddressDto
                                {
                                    City = racer.City,
                                    Country = "Czech Republic",
                                    Region = string.Empty,
                                    ZipCode = string.Empty,
                                    Street = racer.Address,
                                    Position = new CreateActionInternalStorageRequest.LatLngDto
                                    {
                                        Latitude = double.NaN,
                                        Longitude = double.NaN
                                    }
                                },
                                Accepted = true,
                                Payed = true,
                                Email = racer.Email,
                                Phone = racer.Phone,
                                Start = racer.Start,
                                Finish = racer.Finish,
                                Pets = racer.Dogs.Select(dog => new CreateActionInternalStorageRequest.PetDto
                                    {
                                        Id = dog.Id,
                                        Name = dog.Name,
                                        Chip = dog.Chip,
                                        Pedigree = dog.Pedigree,
                                        Birthday = null,
                                        Contact = racer.Email,
                                        Decease = null,
                                        Kennel = string.Empty,
                                        Vaccinations = new(),
                                        UserId = string.Empty,
                                        UriToPhoto = string.Empty
                                    })
                                    .ToList(),
                                FirstName = racer.FirstName,
                                LastName = racer.LastName,
                                Merchandize = racer.TShirtOrders.Select(tso => new CreateActionInternalStorageRequest.MerchandizeItemDto
                                    {
                                        Id = tso.Id.ToString(),
                                        Name = s.TShirts.FirstOrDefault(tsoffer => tsoffer.Id == tso.OfferId) != null 
                                            ? s.TShirts.FirstOrDefault(tsoffer => tsoffer.Id == tso.OfferId)!.Name 
                                            : "",
                                        Color = tso.Color,
                                        Count = (int) Math.Floor(tso.Count),
                                        Currency = "Czk",
                                        Price = tso.Price,
                                        Size = tso.Size,
                                        Variant = "base",
                                        Description = string.Empty,
                                        Note = string.Empty
                                    })
                                    .ToList(),
                                State = RemapRaceState(racer.State),
                                Payments = racer.Payments.Select(payment => new CreateActionInternalStorageRequest.PaymentDto
                                    {
                                        Date = payment.Date,
                                        Amount = payment.Amount,
                                        Currency = payment.Currency,
                                        Note = payment.Note,
                                        BankAccount = payment.BankAccount
                                    })
                                    .ToList()
                            })
                                .ToList()
                        })
                            .ToList(),
                        Payments = race.PaymentDefinitions.Select(pd => new CreateActionInternalStorageRequest.PaymentDefinitionDto
                            {
                                Price = pd.Price,
                                Currency = pd.Currency,
                                From = pd.From,
                                To = pd.To,
                                Id = pd.Id,
                                BankAccount = pd.BankAccount
                            })
                            .ToList()
                    })
                    .ToList()

            });
     
        return typeAdapterConfig;
    }

    private static CreateActionInternalStorageRequest.RaceState RemapRaceState(FullActionModel.RaceState state)
    {
        switch (state)
        {
            case FullActionModel.RaceState.NotStarted: return CreateActionInternalStorageRequest.RaceState.NotStarted;
            case FullActionModel.RaceState.Started: return CreateActionInternalStorageRequest.RaceState.Started;
            case FullActionModel.RaceState.Finished: return CreateActionInternalStorageRequest.RaceState.Finished;
            case FullActionModel.RaceState.DidNotFinished:
                return CreateActionInternalStorageRequest.RaceState.DidNotFinished;
            case FullActionModel.RaceState.Disqualified:
                return CreateActionInternalStorageRequest.RaceState.Disqualified;
            
            default: return CreateActionInternalStorageRequest.RaceState.NotValid;
        }
        
        return CreateActionInternalStorageRequest.RaceState.NotValid;
    }
}