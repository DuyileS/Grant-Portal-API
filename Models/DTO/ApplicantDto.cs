using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GMP.API.Models.Domain;

namespace GMP.API.Models.DTO
{
    public class ApplicantDto
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public bool IsStaffMember { get; set; }
        public DocumentDto Document { get; set; }
    }
}
