using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Domain.Interfaces
{
    public interface IGroupRepository
    {
        Task<bool> ExistGroupByIdAsync(int id, CancellationToken cancellationToken);
    }
}
