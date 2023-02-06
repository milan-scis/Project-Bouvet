using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BouvetTask.Dtos.Epic
{
    public class AddEpicDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
