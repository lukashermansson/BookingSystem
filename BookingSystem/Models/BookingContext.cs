using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookingSystem.Models
{
   

    public class BookingDbContext : DbContext
    {
        public BookingDbContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        
        public DbSet<TableModel> Tables { get; set; }
        public DbSet<SeatModel> Seats { get; set; }
        public DbSet<CodeModel> Codes { get; set; }
        public DbSet<TableGroupModel> TableGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            
    
        }
        
           
        
    }
}