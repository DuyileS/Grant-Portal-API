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
