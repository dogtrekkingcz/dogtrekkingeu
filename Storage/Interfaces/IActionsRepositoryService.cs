using Storage.Entities.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IActionsRepositoryService : IRepositoryService
    {
        public Task<AddActionResponse> AddActionAsync(AddActionRequest request);

        public Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request);

        public Task<GetAllActionsResponse> GetAllActionsAsync();
    }
}
