using DogtrekkingCz.Storage.Models;
using MapsterMapper;
using Storage.Entities.Actions;
using Storage.Interfaces;
using Storage.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Services.Repositories
{
    internal class ActionsRepositoryService : IActionsRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IStorageService<ActionRecord> _actionsStorageService;

        ActionsRepositoryService(IMapper mapper, IStorageService<ActionRecord> actionsStorageService)
        {
            _mapper = mapper;
            _actionsStorageService = actionsStorageService;
        }

        public async Task<AddActionResponse> AddActionAsync(AddActionRequest request)
        {
            var action = new ActionRecord
            {
                Name = request.Name,
                Description = request.Description,
                Owner = new ActionRecord.OwnerDto
                {
                    Id = request.Owner.Id,
                    Email = request.Owner.Email,
                    FirstName = request.Owner.FirstName,
                    FamilyName = request.Owner.FamilyName
                }
            };

            var addedActionRecord = await _actionsStorageService.AddAsync(action);

            var response = _mapper.Map<AddActionResponse>(addedActionRecord);

            return response;
        }

        public async Task<GetAllActionsResponse> GetAllActionsAsync()
        {
            var getAllActions = await _actionsStorageService.GetAllAsync();

            var response = _mapper.Map<GetAllActionsResponse>(getAllActions);

            return response;
        }
    }
}
