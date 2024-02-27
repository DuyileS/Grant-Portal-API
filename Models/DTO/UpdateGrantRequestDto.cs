using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.DTO
{
    public class UpdateGrantRequestDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Criteria { get; set; }
        [Required]
        public string Deadline { get; set;}
    }
}
