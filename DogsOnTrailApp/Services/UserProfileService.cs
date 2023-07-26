﻿using DogsOnTrailApp.Models;
using MapsterMapper;

namespace DogsOnTrailApp.Services;

public sealed class UserProfileService : IUserProfileService
{
    private UserProfileModel _userProfileModel = new();

    private readonly IMapper _mapper;

    public UserProfileService(IMapper mapper)
    {
        _mapper = _mapper;
    }
    
    public UserProfileModel Get()
    {
        return _userProfileModel;
    }

    public void SetUserProfile(UserProfileModel userProfileModel)
    {
        var rights = _userProfileModel.Rights;
        _userProfileModel = _mapper.Map<UserProfileModel>(userProfileModel)
            with
            {
                Rights = rights
            };
    }
    
    public void SetRights(IList<UserProfileModel.ActionRightsDto> rights)
    {
        _userProfileModel.Rights = rights;
    }
}