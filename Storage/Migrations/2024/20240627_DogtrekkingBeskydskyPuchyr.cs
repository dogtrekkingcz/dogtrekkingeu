using System.Collections.Generic;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Storage.Migrations._2024;

internal class _20240627_DogtrekkingBeskydskyPuchyr : M_00_MigrationBase
{
    protected override Guid Id { get; init; } = Guid.Parse("2d87002d-611e-4130-99d9-564b7d4d6fb5");
    protected override string Name { get; init; } = nameof(_20240627_DogtrekkingBeskydskyPuchyr);


    public _20240627_DogtrekkingBeskydskyPuchyr(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this
            .AddUpAction(() => ActionsRepositoryService.AddActionAsync(new Entities.Actions.CreateActionInternalStorageRequest
            {
                Id = Id,
                Name = "Dogtrekking Beskydský puchýř",
                TypeId = Constants.ActivityType.Dogtrekking,
                ResultsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                CompetitorsCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                ActionCanEdit = new List<Guid> { Constants.Roles.InternalAdministrator.GUID },
                Address = new Entities.Actions.CreateActionInternalStorageRequest.AddressDto
                {
                    City = "Palkovice",
                    Country = "Czech Republic",
                    Street = "Rekreační středisko Palkovické Hůrky, Palkovice 226",
                    ZipCode = "739 41"
                },
                Term = new Entities.Actions.CreateActionInternalStorageRequest.TermDto
                {
                    From = new DateTime(2024, 6, 27, 17, 0, 0),
                    To = new DateTime(2024, 6, 30, 13, 0, 0)
                },
                Www = "https://beskydskaliska.webnode.cz/",
                Races = new List<Entities.Actions.CreateActionInternalStorageRequest.RaceDto>
                {
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("2b34bf0e-800a-46e3-aa50-4820d4788481"),
                        Name = "Dogtrekking",
                        Distance = 93,
                        Incline = 2471,
                        Begin = new DateTime(2024, 6, 28, 5, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("42719606-a893-4cf2-8e2e-98ad19dbc648"),
                                Name = "DTW 1",
                                Description = "Ženy do 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Fránková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Belatrix Chlupatý nesmysl",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Nikol",
                                        LastName = "Hamáková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Argo",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Eliška",
                                        LastName = "Vasilenková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Haku",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Luisa",
                                        LastName = "Wáwrová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Femina Famosa Canis Mayrau",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("9e62f74b-008f-4799-8538-bbb34a48c637"),
                                Name = "DTW 2",
                                Description = "Ženy nad 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Milena",
                                        LastName = "Bauerová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Isla Bonita Jednička",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Helena",
                                        LastName = "Bayerová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Darko",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Čiperová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Myška",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Knopová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Pony",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Horalka",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Romana",
                                        LastName = "Kratochvílová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Babette Vardarianna",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Renáta",
                                        LastName = "Libová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Eddie",
                                                Kennel = "Expert Belrott",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marie",
                                        LastName = "Payne",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Frída",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jaroslava",
                                        LastName = "Radová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Baltazar",
                                                Kennel = "Vločka z Beskyd",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marcela",
                                        LastName = "Vlčková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "I'Khalessi",
                                                Kennel = "Vlčí tlapka",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("75d84ef9-a9fe-49bf-9d61-f2c2c0bcd4ef"),
                                Name = "DTM 1",
                                Description = "Muži do 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Michal",
                                        LastName = "Durišík",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Andromeda",
                                                Kennel = "od Pstruhové vody",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jiří",
                                        LastName = "Tyl",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Andy",
                                                Kennel = "Chlupatý nesmysl",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bella",
                                                Kennel = "Chlupatý nesmysl",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("20c728ed-3312-46b5-a608-5ef402445005"),
                                Name = "DTM 2",
                                Description = "Muži nad 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Vít",
                                        LastName = "Bauer",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Honey",
                                                Kennel = "Jednička",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jaroslav",
                                        LastName = "Dustir",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Goa",
                                                Kennel = "Kronebox",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Grand Merci",
                                                Kennel = "Almandinaks",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jiří",
                                        LastName = "Egg",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Isildur",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Roman",
                                        LastName = "Polášek",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Apu",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Šeda",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Hick",
                                                Kennel = "Sideric Miks",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Michal",
                                        LastName = "Vejtasa",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Delinka",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Karlička",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("8baddf26-ad2e-46c5-91ea-f4483cc18bcc"),
                        Name = "Dogmid",
                        Distance = 45 ,
                        Incline = 890,
                        Begin = new DateTime(2024, 6, 29, 6, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("aeaabd9c-30db-4f11-952f-c2aeebe990ca"),
                                Name = "DMW 1",
                                Description = "Ženy do 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Silvie",
                                        LastName = "Beránková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Hodor",
                                                Kennel = "Aussieland",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Holá",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Marvin",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Miriam",
                                        LastName = "Hrivňáková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Barbara",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ali",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Andrea",
                                        LastName = "Kiculisová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Teo",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Iveta",
                                        LastName = "Landová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Zack",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Tereza",
                                        LastName = "Mokrá",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Hak",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Henry",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Anna",
                                        LastName = "Soukupová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Rufi",
                                                Kennel = "Fleret Moravia",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Collin",
                                                Kennel = "Fleret Moravia",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Magdaléna",
                                        LastName = "Wojatschke",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Akim",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("20bc0735-ac89-4b18-8601-cac457bdcce2"),
                                Name = "DMW 2",
                                Description = "Ženy nad 35 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Adamíková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Izzie",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Hana",
                                        LastName = "Bartoňková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cody",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marie",
                                        LastName = "Brožová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Dacota",
                                                Kennel = "Ligoretto",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Čápová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Devon",
                                                Kennel = "Di-Le-Grej",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Radka",
                                        LastName = "Černá",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Shelby",
                                                Kennel = "Vlčí tlapka",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Mirka",
                                        LastName = "Davidová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Torin",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jiřina",
                                        LastName = "Jelenová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Kili",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Irena",
                                        LastName = "Málková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Artuš",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Magda",
                                        LastName = "Maralíková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Žofie",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Radvanská",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Edith",
                                                Kennel = "Yabalute",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ewa",
                                        LastName = "Skubida",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Erka",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ladislava",
                                        LastName = "Smékalová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Annie",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petra",
                                        LastName = "Staňková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Calypso",
                                                Kennel = "Northern Shadows",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Eva",
                                        LastName = "Šišoláková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Koda",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petra",
                                        LastName = "Škrbelová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Orca",
                                                Kennel = "Navarrewolf",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Markéta",
                                        LastName = "Vítková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Pazienza Amore Gas",
                                                Kennel = "B.G's Phantasia",
                                                PetType = Constants.PetType.Dog
                                            },
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "I'm Idaho",
                                                Kennel = "B.G's Phantasia",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Votřelová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bonnie",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Wičarová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bárt",
                                                Kennel = "ZAPLACENO",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("57acdf69-a6f7-49b7-a665-3c3b217a8423"),
                                Name = "DMM 1",
                                Description = "Muži do 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Gabriel",
                                        LastName = "Bílý",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Sky",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lukáš",
                                        LastName = "Družba",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aisha",
                                                Kennel = "Dogcentrum's Guardian",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petr",
                                        LastName = "Holeksa",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Argo",
                                                Kennel = "Kutnohorský groš",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Mokrý",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Fira",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jakub",
                                        LastName = "Staněk",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Arny",
                                                Kennel = "Ledové tlapky naděje",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            },
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("089f5dc3-0f02-4ee5-923c-3d238f7cf2a4"),
                                Name = "DMM 2",
                                Description = "Muži nad 40 let",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Antoš",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Arny",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Broža",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Breath of Highland Tullibeardie",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martin",
                                        LastName = "Hanslík",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Tessi z Býchorska",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ondřej",
                                        LastName = "Jareš",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "India z Majklovy zahrady",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ondřej",
                                        LastName = "Kryl",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Thor",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martin",
                                        LastName = "Svrček",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Olaf",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Vladimír",
                                        LastName = "Wičar",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Chilli",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("12cd4b53-aa18-4adb-be5e-08ac5cc017cc"),
                        Name = "Short",
                        Distance = 21,
                        Begin = new DateTime(2024, 6, 29, 8, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("061034ce-31ec-4f28-96f6-c816ea930e1e"),
                                Name = "Short",
                                Description = "Všichni bez rozdílu",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marie",
                                        LastName = "Adamcová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Baldur Dog Arabat",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Zuzana",
                                        LastName = "Adamcová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ares Ritter von Falkenberg",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jan",
                                        LastName = "Bayer",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aiko",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Gabriela",
                                        LastName = "Čejková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Cita Cele Brita",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Hana",
                                        LastName = "Fuksová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Conie",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Gerychová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bailey",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kateřina",
                                        LastName = "Jedličková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bella Rosa Bohemian Edition",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Petra",
                                        LastName = "Klimosz",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ford",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Kamila",
                                        LastName = "Knoppová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aura",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Tereza",
                                        LastName = "Kotasová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Ave Aura Black",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lucie",
                                        LastName = "Kratochvílová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Enny",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Macečková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Max",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lenka",
                                        LastName = "Mikulcová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Akira",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Mlýnková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Sky",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martina",
                                        LastName = "Mücková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Gery",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ľubica",
                                        LastName = "Oczková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Biri",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Iveta",
                                        LastName = "Pfeilerová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Griff",
                                                Kennel = "Gin Fizz Griffella",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Plachá",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Argo",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Matej",
                                        LastName = "Plieštik",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Aspen Lupus Aurea",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martina",
                                        LastName = "Polášková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Heartbreaker Snowflake of Angel",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Radka",
                                        LastName = "Polášková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Roxy",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Pavel",
                                        LastName = "Prokop",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Chelsea",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Lukáš",
                                        LastName = "Sebera",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Dasty",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Michal",
                                        LastName = "Sedláček",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Chinedu Badi Wandelmere",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Zuzana",
                                        LastName = "Smržová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Izabella a Elizabeth",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Daniel",
                                        LastName = "Surý",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Loki",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Martina",
                                        LastName = "Trajteľová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Marlon Čierny ónyx",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Veronika",
                                        LastName = "Urbanová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Houba",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Ivana",
                                        LastName = "Válková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Bella - Blair To Be Sunny Amaranthe",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Marta, MVDr.",
                                        LastName = "Vojkůvková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Jackie",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Dita",
                                        LastName = "Vondráková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Kira",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new Entities.Actions.CreateActionInternalStorageRequest.RaceDto
                    {
                        Id = Guid.Parse("d9431a85-5894-4e6d-8534-49e10b2a9546"),
                        Name = "Dětská / štěněcí",
                        Distance = 3,
                        Begin = new DateTime(2024, 6, 29, 8, 0, 0),
                        End = new DateTime(2024, 6, 30, 10, 0, 0),
                        Categories = new List<Entities.Actions.CreateActionInternalStorageRequest.CategoryDto>
                        {
                            new Entities.Actions.CreateActionInternalStorageRequest.CategoryDto
                            {
                                Id = Guid.Parse("446be227-1059-4311-9f9a-521195476835"),
                                Name = "Dětská / štěněcí",
                                Description = "Všichni bez rozdílu",
                                Racers = new List<Entities.Actions.CreateActionInternalStorageRequest.RacerDto>
                                {
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Elen",
                                        LastName = "Hroteková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Daiquiri z Faustovy zahrádky",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Jana",
                                        LastName = "Hubálková",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Sam",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Richard",
                                        LastName = "Gajdošík",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Loki",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    },
                                    new Entities.Actions.CreateActionInternalStorageRequest.RacerDto
                                    {
                                        FirstName = "Iveta",
                                        LastName = "Landová",
                                        Pets = new List<Entities.Actions.CreateActionInternalStorageRequest.PetDto>
                                        {
                                            new Entities.Actions.CreateActionInternalStorageRequest.PetDto
                                            {
                                                Name = "Balů",
                                                Kennel = "",
                                                PetType = Constants.PetType.Dog
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                }

            }, CancellationToken.None))

            .AddDownAction(() => ActionsRepositoryService.DeleteActionAsync(Id, CancellationToken.None));
    }
}
