using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.Models.Dto
{
    public class RegisterDto
    {
        public int UserId { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }
        public string Gender {  get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
