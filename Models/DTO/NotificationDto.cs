using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.DTO
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Type { get; set; }
    }
}
