using System;
using System.Collections.Generic;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Storage.Interfaces.Entities;

public sealed record AddActionRequest
{
    public OwnerRecord Owner { get; set; }
    
    public required string Name { get; set; }
    
    public string Description { get; set; }
    

    public sealed record AddressRecord
    {
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Longitude { get; set; }
        
        public string Latitude { get; set; }
    }
    
    public sealed record OwnerRecord
    {
        public string Id { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
    }
}