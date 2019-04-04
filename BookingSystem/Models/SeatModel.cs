namespace BookingSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class SeatModel 
    {
        [Key]
        public int Id { get; set; }
        
        public CodeModel Code { get; set; }
        public String Name { get; set; }


        public virtual bool IsBooked
        {
            get
            {
                return Code != null;
            }
        }
    }

    
}