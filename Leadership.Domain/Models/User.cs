using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Leadership.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public ICollection<Participant>? Participants { get; set; }
    }
}
