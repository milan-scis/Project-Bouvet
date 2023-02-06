using System.Collections.Generic;
using BouvetTask.Dtos.Epic;

namespace BouvetTask.Dtos.Project
{
    public class GetProjectDto
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectManager { get; set; }
        public virtual ICollection<GetEpicDto> Epics { get; set; }
    }
}
