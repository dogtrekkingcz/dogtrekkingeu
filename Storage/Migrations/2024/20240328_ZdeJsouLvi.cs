namespace Storage.Migrations._2024;

internal class _20240328_ZdeJsouLvi : M_00_MigrationBase
{
    private Guid _guid = Guid.Parse("e155cf24-1147-453a-8d08-0010a1dfceb7");

    public _20240328_ZdeJsouLvi(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task UpAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = _guid,
            Name = "ZDE JSOU LVI",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Rychta a fara v Úvalně"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 3, 28, 17, 0, 0),
                To = new DateTime(2024, 3, 31, 13, 0, 0)
            },
            Races = new List<Entities.Actions.CreateActionInternalStorageRequest.RaceDto> {
                new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                {
                    Name = "Dogtrekking",
                    Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                    {
                        new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                        {
                            Name = "DTW1",
                            Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                            {
                                new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                {
                                    FirstName = "jméno",
                                    LastName = "Příjmení",
                                    Start = new DateTime(2024, 3, 28, 17, 0, 0),
                                    Finish = new DateTime(2024, 3, 31, 13, 0, 0)
                                }
                            }
                        },
                        new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                        {
                            Name = "DTM1"
                        },
                        new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                        {
                            Name = "DTW2"
                        },
                        new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                        {
                            Name = "DTM2"
                        }
                    }
                }
            }
        }, cancellationToken);
    }

    public override async Task DownAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.DeleteActionAsync(_guid, cancellationToken);
    }
}
