using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repository
{
    public interface IProjectRepository
    {
        Task<bool> Exist(int id);
    }
}
