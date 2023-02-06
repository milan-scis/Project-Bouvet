namespace BouvetTask.Dtos.Task
{
    public class GetTaskDto
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EpicId { get; set; }
    }
}
