using System.ComponentModel.DataAnnotations;

namespace GMP.API.Models.Domain
{
    public class Grant
    {

        public Grant()
        {
            DateCreated = DateTimeOffset.UtcNow;
            DateModified = DateTimeOffset.UtcNow;
        }

        [Key]
        public Guid GrantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Criteria { get; set; }
        public string Deadline { get; set; } 
        public DateTimeOffset DateCreated { get; set; } 
        public DateTimeOffset DateModified { get; set; }
        public ICollection<GrantApplicant> GrantApplicants { get; set; }
    }
}
