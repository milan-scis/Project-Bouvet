namespace BouvetTask.Dtos.Epic
{
    public class UpdateEpicDto
    {
        public int EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
