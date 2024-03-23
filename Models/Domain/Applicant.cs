using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMP.API.Models.Domain
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public bool IsStaffMember { get; set; }

        [ForeignKey("Document")]
        public int? DocumentId { get; set; }
        public Document Document { get; set; }

      // public ICollection<GrantApplicant> GrantApplicants { get; set; }
    }
}

/*
 using System.ComponentModel.DataAnnotations.Schema;

namespace GMP.API.Models.Domain
{
    public class GrantApplicant
    {
        [ForeignKey("Grant")]
        public Guid GrantId { get; set; }
        public Grant Grant { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}

*/