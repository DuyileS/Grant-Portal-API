using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.DTO
{
    public class AddTaskRequestDto
    {
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TaskStatus { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        [Required]
        public string AssignedFrom { get; set; }
    }
}
