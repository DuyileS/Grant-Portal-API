using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.Domain
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Type { get; set; }

    }
}
