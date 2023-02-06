using System;
using System.Collections.Generic;

#nullable disable

namespace BouvetTask.Models
{
    public partial class Project
    {
        public Project()
        {
            Epics = new HashSet<Epic>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectManager { get; set; }

        public virtual ICollection<Epic> Epics { get; set; }
    }
}
