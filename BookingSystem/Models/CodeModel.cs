namespace BookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class CodeModel
    {
        [Key]
        public String Code { get; set; }
        public bool IsGiven { get; set; }

        [ScriptIgnore]
        
        public virtual ICollection<SeatModel> Seats { get; set; }

        public CodeModel()
        {
            Seats = new List<SeatModel>();
        }
    }

   
}