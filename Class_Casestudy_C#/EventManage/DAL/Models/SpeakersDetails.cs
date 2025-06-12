using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SpeakersDetails
    {
        [Key]
        public int SpeakerId { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [Required]
        public string SpeakerName { get; set; }
    }
}
