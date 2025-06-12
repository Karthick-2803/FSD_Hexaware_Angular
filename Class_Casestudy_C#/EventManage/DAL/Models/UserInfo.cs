using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserInfo
    {
        [Key]
        [EmailAddress]
        public string EmailId { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("Admin|Participant")]
        public string Role { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 6)]
        [Required]
        public string Password { get; set; }
    }
}
