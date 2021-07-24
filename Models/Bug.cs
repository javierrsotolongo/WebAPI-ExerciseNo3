using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Models
{
    public class Bug
    {
        public int BugId { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

    }
}
