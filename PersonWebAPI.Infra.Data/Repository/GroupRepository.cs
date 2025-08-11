using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Domain.Interfaces;
using PersonWebAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Infra.Data.Repository
{
    public class GroupRepository(PersonWebAPIContext context) : IGroupRepository
    {
        public async Task<bool> ExistGroupByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await context.Groups.AnyAsync(g => g.GroupId == id, cancellationToken);

            return result;
        }
    }
}
