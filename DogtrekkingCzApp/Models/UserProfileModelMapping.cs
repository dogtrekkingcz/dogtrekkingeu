using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Extensions;
using Mapster;

namespace DogtrekkingCzApp.Models;

internal static class UserProfileModelMapping
{
    internal static TypeAdapterConfig AddUserProfileModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.UserProfile, UserProfileModel>()
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<UserProfileModel, Protos.Shared.UserProfile>()
            .Map(d => d.Birthday, s => s.Birthday.ToGoogleDateTime());

        typeAdapterConfig.NewConfig<Protos.UserProfiles.GetUserProfileResponse, UserProfileDto>()
            .MapWith(s => new UserProfileDto
            {
                Id = s.UserProfile.Id,
                UserId = s.UserProfile.UserId,
                Address = new AddressDto
                {
                    City = s.UserProfile.Address.City,
                    Country = s.UserProfile.Address.Country,
                    Position = new LatLngDto
                    {
                        GpsLatitude = s.UserProfile.Address.Position.Latitude,
                        GpsLongitude = s.UserProfile.Address.Position.Longitude
                    },
                    Region = s.UserProfile.Address.Region,
                    Street = s.UserProfile.Address.Street
                },
                Birthday = s.UserProfile.Birthday.ToDateTimeOffset(),
                Contact = new ContactDto
                {
                    EmailAddress = s.UserProfile.Contact.EmailAddress,
                    PhoneNumber = s.UserProfile.Contact.PhoneNumber
                },
                Dogs = s.UserProfile.Dogs
                    .Select(dog => new DogDto
                    {
                        Birthday = dog.Birthday.ToDateTimeOffset(),
                        Name = dog.Name,
                        Chip = dog.Chip,
                        Decease = dog.Decease.ToDateTimeOffset(),
                        Id = dog.Id,
                        Pedigree = dog.Pedigree,
                        UriToPhoto = dog.UriToPhoto,
                        Vaccinations = dog.Vaccinations
                            .Select(vacc => new DogDto.VaccinationDto
                            {
                                UriToPhoto = vacc.UriToPhoto,
                                Date = vacc.Date.ToDateTimeOffset(),
                                Note = vacc.Note,
                                ValidUntil = vacc.ValidUntil.ToDateTimeOffset(),
                                Type = (DogDto.VaccinationType)vacc.Type
                            })
                            .ToList()
                    })
                    .ToList(),
                Nickname = s.UserProfile.Nickname,
                CompetitorId = Guid.Parse(s.UserProfile.CompetitorId),
                FirstName = s.UserProfile.FirstName,
                LastName = s.UserProfile.LastName
            });
        
        return typeAdapterConfig;
    }
}