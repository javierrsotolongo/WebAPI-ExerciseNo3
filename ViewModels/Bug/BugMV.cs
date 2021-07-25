using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.ViewModels.Bug
{
    public class BugMV
    {

        public int BugId { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

    }
}
