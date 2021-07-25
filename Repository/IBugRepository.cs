using BugsManager.ViewModels.Bug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repository
{
    public interface IBugRepository
    {
        Task<BugMV> Create(CreateBugVM bug);
        Task<BugMV> Get(int id);

        Task<IEnumerable<BugDataMV>> GetFilter(int? projectId, int? userId);
    }
}
