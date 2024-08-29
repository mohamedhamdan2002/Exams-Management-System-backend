// Ignore Spelling: Admin

using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string NationalID { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<ExamSolution> ExamSolutions { get; set; } = new List<ExamSolution>();
        public bool IsStaff { get; set; }
    }
}
