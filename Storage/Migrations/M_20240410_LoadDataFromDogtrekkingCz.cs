using Storage.Entities.ActionRights;
using Storage.Entities.AuthorizationRoles;
using Storage.Entities.UserProfiles;

namespace Storage.Migrations;

internal class M_20240410_LoadActionsForYear2024 : M_00_MigrationBase
{
    public override async Task RunAsync(CancellationToken cancellationToken)
    {
        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "ZDE JSOU LVI",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Rychta a fara v Úvalně"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 3, 28, 17, 0, 0),
                To = new DateTime(2024, 3, 31, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Šlapanický vlk",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Šlapanice"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 4, 11, 17, 0, 0),
                To = new DateTime(2024, 4, 14, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Krušnohorský dogtrekking",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kemp Stebnice, obec Lipová u Chebu"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 4, 25, 17, 0, 0),
                To = new DateTime(2024, 4, 28, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "DT Rudolf jede na Sázavu",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kácov"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 5, 9, 17, 0, 0),
                To = new DateTime(2024, 5, 12, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "V srdci Česka",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Kemp MOŘE, rybník ŘEKA, Krucemburk"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 5, 30, 17, 0, 0),
                To = new DateTime(2024, 6, 2, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "DT Krajem břidlice",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Šternberk"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 6, 13, 17, 0, 0),
                To = new DateTime(2024, 6, 16, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Dogtrekking Beskydský puchýř",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Palkovice"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 6, 27, 17, 0, 0),
                To = new DateTime(2024, 6, 30, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Stopou strejdy Šeráka",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Lipová lázně"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 7, 12, 17, 0, 0),
                To = new DateTime(2024, 7, 14, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Fryštácký dogtrekking",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Ranč kemp Bystřička"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 9, 5, 17, 0, 0),
                To = new DateTime(2024, 9, 8, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "DT Košťálov",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Košťálov"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 9, 19, 17, 0, 0),
                To = new DateTime(2024, 9, 22, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Dogtrekking za pokladem Voka IV. z Holštejna",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Moravský kras"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 10, 3, 17, 0, 0),
                To = new DateTime(2024, 10, 6, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Valašská Vlčica - Memoriál Alči Veselé",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Chřiby"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 10, 25, 17, 0, 0),
                To = new DateTime(2024, 10, 28, 13, 0, 0)
            }
        }, cancellationToken);

        await ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            Name = "Dogtrekking Bílé Karpaty",
            Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
            {
                City = "Bílé Karpaty"
            },
            Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
            {
                From = new DateTime(2024, 10, 17, 17, 0, 0),
                To = new DateTime(2024, 10, 20, 13, 0, 0)
            }
        }, cancellationToken);
    }
}