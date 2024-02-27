using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.DTO
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string TaskStatus { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedFrom { get; set; }
    }
}
