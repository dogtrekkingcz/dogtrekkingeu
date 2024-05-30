using PetsOnTrail.Interfaces.Actions.Entities.Pets;
using Mapster;
using API.GRPCService.Extensions;

namespace API.GRPCService.Services.Pets;

internal static class PetsServiceMapping
{
    internal static TypeAdapterConfig AddPetsServiceMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.CreatePetRequest, CreatePetRequest>();
        typeAdapterConfig.NewConfig<Protos.Pets.CreatePet.Vaccination, CreatePetRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<CreatePetResponse, Protos.Pets.CreatePet.CreatePetResponse>();

        typeAdapterConfig.NewConfig<Protos.Pets.GetAllPets.GetAllPetsRequest, GetAllPetsRequest>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse, Protos.Pets.GetAllPets.GetAllPetsResponse>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.PetDto, Protos.Pets.GetAllPets.PetDto>();
        typeAdapterConfig.NewConfig<GetAllPetsResponse.VaccinationDto, Protos.Pets.GetAllPets.Vaccination>();
        
        typeAdapterConfig.NewConfig<Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipRequest, GetPetsFilteredByChipRequest>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse, Protos.Pets.GetPetsFilteredByChip.GetPetsFilteredByChipResponse>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.PetDto, Protos.Pets.GetPetsFilteredByChip.PetDto>();
        typeAdapterConfig.NewConfig<GetPetsFilteredByChipResponse.VaccinationDto, Protos.Pets.GetPetsFilteredByChip.Vaccination>();

        typeAdapterConfig.NewConfig<Protos.Pets.DeletePet.DeletePetRequest, DeletePetRequest>();
        typeAdapterConfig.NewConfig<DeletePetResponse, Protos.Pets.DeletePet.DeletePetResponse>();
        
        typeAdapterConfig.NewConfig<GetPetResponse, Protos.Pets.GetPet.GetPetResponse>();
        typeAdapterConfig.NewConfig<GetPetResponse.VaccinationDto, Protos.Pets.GetPet.Vaccination>();

        typeAdapterConfig.NewConfig<Protos.Pets.UpdatePet.UpdatePetRequest, UpdatePetRequest>();
        typeAdapterConfig.NewConfig<Protos.Pets.UpdatePet.Vaccination, UpdatePetRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<UpdatePetResponse, Protos.Pets.UpdatePet.UpdatePetResponse>();

        typeAdapterConfig.NewConfig<Protos.Pets.GetMyPets.GetMyPetsRequest, GetMyPetsRequest>()
            .Ignore(d => d.UserId);
        typeAdapterConfig.NewConfig<GetMyPetsResponse, Protos.Pets.GetMyPets.GetMyPetsResponse>()
            .MapWith(s => new Protos.Pets.GetMyPets.GetMyPetsResponse
            {
                Pets = 
                { 
                    s.Pets.Select(p => new Protos.Pets.GetMyPets.MyPet
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Chip = p.Chip,
                        Birthday = p.Birthday.ToGoogleDateTime(),
                        Contact = p.Contact,
                        Decease = p.Decease.ToGoogleDateTime(),
                        Kennel = p.Kennel,
                        Pedigree = p.Pedigree,
                        UriToPhoto = p.UriToPhoto,
                        UserId = p.UserId,
                        PetType = p.PetType.ToString(),
                        Vaccinations = {
                            p.Vaccinations.Select(v => new Protos.Pets.GetMyPets.VaccinationDto
                            {
                                Date = v.Date.ToGoogleDateTime(),
                                VaccinationType = v.VaccinationType.ToString(),
                                Note = v.Note,
                                UriToPhoto = v.UriToPhoto,
                                ValidUntil = v.ValidUntil.ToGoogleDateTime()
                            }).ToList()
                        }

                    }).ToList()
                }
            });

        typeAdapterConfig.NewConfig<Protos.Pets.AddMyPet.AddMyPetRequest, AddMyPetRequest>();
        typeAdapterConfig.NewConfig<Protos.Pets.AddMyPet.VaccinationDto, AddMyPetRequest.VaccinationDto>();
        typeAdapterConfig.NewConfig<AddMyPetResponse, Protos.Pets.AddMyPet.AddMyPetResponse>();
        
        return typeAdapterConfig;
    }
}
