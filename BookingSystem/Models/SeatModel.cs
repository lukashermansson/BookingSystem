namespace BookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class SeatModel 
    {
        [Key]
        public int Id { get; set; }
        [ScriptIgnore]
        public ICollection<CodeModel> Codes { get; set; }
        public String Name { get; set; }

        public SeatModel ()
        {
            Codes = new List<CodeModel>();
        }

        


        public virtual bool IsBooked
        {
            get
            {
                return Codes.FirstOrDefault() != null;
            }
        }
    }

    
}