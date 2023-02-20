﻿using System;
using System.Collections.Generic;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Storage.Entities.Actions;

public sealed record AddActionRequest
{
    public required string Name { get; set; }

    public OwnerDto Owner { get; set; }

    public TermDto Term { get; set; }
    public string Description { get; set; }


    public sealed record AddressRecord
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
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
}