﻿using DogtrekkingCz.Storage.Models;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; }

    public sealed record ActionDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public OwnerDto Owner { get; set; }

        public string Description { get; set; }
        
        public TermDto Term { get; set; }
        
        public AddressDto Address { get; set; }

        public IReadOnlyList<RaceDto> Races { get; set; }
        
        public FlagsDto Flags { get; set; }
    }

    public sealed record OwnerDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }
    }

    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
    
    public sealed record AddressDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
    }

    public class RaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Distance { get; set; }
        public double? Incline { get; set; }
    }
    
    public class FlagsDto
    {
        public bool IsHidden { get; set; }
        
        public bool IsCanceled { get; set; }
        public string CancelledReason { get; set; }
        
        public bool TermLocked { get; set; }
        
        public bool Approved { get; set; }
    }
}