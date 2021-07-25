using BugsManager.Repository;
using BugsManager.ViewModels.Bug;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BugController : Controller
    {
        
        private readonly IBugRepository _bugRepository;
        
        private readonly IProjectRepository _projectRepository;
        
        private readonly IUserRepository _userRepository;

        public BugController(IBugRepository bugRepository, 
            IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _bugRepository = bugRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BugMV>> GetBug(int id)
        {
            var bug = await _bugRepository.Get(id);
            return Ok(bug);
        }

        [HttpGet("~/bugs")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BugDataMV))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult<IEnumerable<BugDataMV>>> GetBugs([FromQuery] int? projectId, [FromQuery] int? userId)
        {
            if (projectId == null && userId == null)
            {
                return BadRequest();
            }

            if (projectId != null && ! await _projectRepository.Exist(projectId.Value))
            {
                return NotFound();
            }

            if (userId != null && !await _userRepository.Exist(userId.Value))
            {
                return NotFound();
            }

            var bugs = await _bugRepository.GetFilter(projectId, userId);
            return Ok(bugs);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBug(CreateBugVM bugVM)
        {
            var bug = await _bugRepository.Create(bugVM);
            return CreatedAtAction(nameof(GetBug), new { id = bug.BugId }, bug);
        }

    }
}
