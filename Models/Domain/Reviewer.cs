using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMP.API.Models.Domain
{
    public class Reviewer
    {
        [Key]
        public int ReviewerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ExpertiseArea { get; set; }

        [ForeignKey("Task")]
        public int? TaskId { get; set; }
        public Task? Task { get; set; }

        [ForeignKey("Document")]
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }

    }
}
