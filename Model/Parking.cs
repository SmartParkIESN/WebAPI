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
        [Required]
        public long PlaceId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public Place Place { get; set; }
        [Required]
        public User User { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }       
    }
}
