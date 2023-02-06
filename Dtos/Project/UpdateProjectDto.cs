namespace BouvetTask.Dtos.Project
{
    public class UpdateProjectDto
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectManager { get; set; }
    }
}
