using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GMP.API.Models.Domain;
using Task = GMP.API.Models.Domain.Task;

namespace GMP.API.Models.DTO
{
    public class ReviewerDto
    {
        public int ReviewerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ExpertiseArea { get; set; }
        public Task Task { get; set; }
        public Document Document { get; set; }
    }
}
