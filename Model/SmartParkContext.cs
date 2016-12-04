using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SmartParkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Announcement> Annoucements { get; set; }
        public DbSet<Reporting> Reportings { get; set; }
        public SmartParkContext()
            : base(@"Data Source=smartparkiesn.database.windows.net,1433;Initial Catalog=SmartPark;Persist Security Info=False;User ID=smartpark;Password=smart123456789!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {

        }
    }
}
