using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repository
{
    public interface IUserRepository
    {
        Task<bool> Exist(int id);
    }
}
