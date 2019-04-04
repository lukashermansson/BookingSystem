using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class TableGroupModel
    {
        [Key]
        public int Id { get; set; }
        
        public String Name { get; set; }
        public List<TableModel> Tables { get; set; }
    }
}