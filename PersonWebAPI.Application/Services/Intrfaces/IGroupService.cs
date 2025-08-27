using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Application.Services.Intrfaces
{
    public interface IGroupService
    {
        Task<bool> ExistGroupByIdAsync(List<int> id , CancellationToken cancellationToken);
    }
}
