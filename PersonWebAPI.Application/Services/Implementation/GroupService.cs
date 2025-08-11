using PersonWebAPI.Application.Services.Intrfaces;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Services.Implementation
{
    public class GroupService(IGroupRepository groupRepository) : IGroupService
    {
        public async Task<bool> ExistGroupByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await groupRepository.ExistGroupByIdAsync(id, cancellationToken);

            return result;
        }
    }
}
