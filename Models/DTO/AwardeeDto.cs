using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GMP.API.Models.Domain;

namespace GMP.API.Models.DTO
{
    public class AwardeeDto
    {
        public int AwardeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public DocumentDto Document { get; set; }
    }
}
