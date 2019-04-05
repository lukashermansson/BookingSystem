using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class SendBookingViewModel
    {
        [Required]
        public int Seat { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Felaktigt namn")]
        public String Name { get; set; }
        [Required]
        public String Code { get; set; }
    }
}