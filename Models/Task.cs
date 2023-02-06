using System;
using System.Collections.Generic;

#nullable disable

namespace BouvetTask.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EpicId { get; set; }

        public virtual Epic Epic { get; set; }
    }
}
