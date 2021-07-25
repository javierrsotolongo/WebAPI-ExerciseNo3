using AutoMapper;
using BugsManager.Models;
using BugsManager.ViewModels.Bug;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Repository
{
    public class BugRepository : IBugRepository
    {

        private readonly BugsManagerContext _context;

        private readonly IMapper _mapper;

        public BugRepository(BugsManagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BugMV> Create(CreateBugVM bugVM)
        {
            var bug = _mapper.Map<Bug>(bugVM);
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();
            return _mapper.Map<BugMV>(bug);
        }

        public async Task<BugMV> Get(int id)
        {
            var bug = await _context.Bugs.FirstOrDefaultAsync(b => b.BugId == id);

            if (bug == null)
            {
                throw new KeyNotFoundException("Bug not found");
            }

            return _mapper.Map<BugMV>(bug);
        }

        public async Task<IEnumerable<BugDataMV>> GetFilter(int? projectId, int? userId)
        {
            IQueryable<Bug> query = _context.Bugs.
                Include(b => b.Project).
                Include(b => b.User);

            if (projectId != null)
            {
                query = query.Where(b => b.ProjectId == projectId.Value);
            }

            if (userId != null)
            {
                query = query.Where(b => b.UserId == userId.Value);
            }

            var bugs = await query.ToListAsync();
            return _mapper.Map<IEnumerable<BugDataMV>>(bugs);
        }
    }
}
