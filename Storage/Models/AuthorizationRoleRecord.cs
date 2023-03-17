using DogtrekkingCz.Storage.Models;
using DogtrekkingCzShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Storage.Models
{
    internal sealed record AuthorizationRoleRecord : AuthorizationRoleDto, IRecord
    {
    }
}
