using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Web.DAL.Models
{
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string EventName { get; set; } = null!;

        [Required, StringLength(50, MinimumLength = 1)]
        public string EventCategory { get; set; } = null!;

        [Required]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        [Required]
        [RegularExpression("Active|In-Active")]
        public string Status { get; set; }
    }
}
