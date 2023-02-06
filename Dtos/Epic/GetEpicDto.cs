using System.Collections.Generic;
using BouvetTask.Dtos.Task;

namespace BouvetTask.Dtos.Epic
{
    public class GetEpicDto
    {
        public int EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public virtual ICollection<GetTaskDto> Tasks { get; set; }
    }
}
