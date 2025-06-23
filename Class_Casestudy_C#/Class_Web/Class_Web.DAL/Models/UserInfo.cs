using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Web.DAL.Models
{
    public class UserInfo
    {
        [Key]
        [Required]
        public string EmailId { get; set; } = null!;

        [Required, StringLength(50, MinimumLength = 1)]
        public string UserName { get; set; } = null!;

        [Required]
        [RegularExpression("Admin|Participant")]
        public string Role { get; set; } = null!;

        [Required, StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
