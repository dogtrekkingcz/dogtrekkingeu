using System;
using System.Collections.Generic;
using DogtrekkingCz.Storage.Models;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Storage.Entities.Actions;

public sealed record DeleteActionRequest
{
    public required string Id { get; set; }
}