using System;
using System.Collections.Generic;

#nullable disable

namespace BouvetTask.Models
{
    public partial class Epic
    {
        public Epic()
        {
            Tasks = new HashSet<Task>();
        }

        public int EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
