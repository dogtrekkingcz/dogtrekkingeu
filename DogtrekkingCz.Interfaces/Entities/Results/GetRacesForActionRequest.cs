﻿namespace DogtrekkingCz.Interfaces.Actions.Entities.Results;

public record GetRacesForActionRequest
{
    public Guid ActionId { get; set; }
}