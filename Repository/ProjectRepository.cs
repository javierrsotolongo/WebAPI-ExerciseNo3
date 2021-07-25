using BugsManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BugsManagerContext _context;

        public ProjectRepository(BugsManagerContext context)
        {
            _context = context;
        }
        public async Task<bool> Exist(int id)
        {
           var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
           return project != null;
        }
    }
}
