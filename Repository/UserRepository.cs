using BugsManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly BugsManagerContext _context;

        public UserRepository(BugsManagerContext context)
        {
            _context = context;
        }
        public async Task<bool> Exist(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user != null;
        }
    }
}
