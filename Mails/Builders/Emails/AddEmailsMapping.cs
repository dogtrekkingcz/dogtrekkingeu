using Mails.Entities;
using Mails.Entities.RegistrationToActionReceived;
using Mapster;

namespace Mails.Builders.Emails;

internal static class EmailsServiceMapping
{
    internal static TypeAdapterConfig AddEmailsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.AddNewActionRegistrationEmailMapping();
        
        return typeAdapterConfig;
    }
}