using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.ViewModels.Bug
{
    public class BugDataMV
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public string Project { get; set; }

    }
}
