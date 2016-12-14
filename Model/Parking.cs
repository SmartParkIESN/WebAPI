using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Parking
    {
        [Key]
        public long ParkingId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        public string Picture { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public long PlaceId { get; set; }
        public long UserId { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }       
    }
}
