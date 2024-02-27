using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.DTO
{
    public class AddApplicantDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "Phone number has to have a minimum of 11 digits")]
        [MaxLength(14, ErrorMessage = "Phone number cannot exceed a maximum of 14 digits")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public bool IsStaffMember { get; set; }

        public int DocumentId { get; set; }

    }
}
