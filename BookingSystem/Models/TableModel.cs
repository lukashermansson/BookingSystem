namespace BookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class TableModel 
    {
        [Key]
        public int Id { get; set; }
        public List<SeatModel> Seats { get; set; }
        
    }

    
}