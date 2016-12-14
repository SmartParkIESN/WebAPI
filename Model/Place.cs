using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Place
    {
        [Key]
        public long PlaceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public ICollection<Parking> Parkings { get; set; }

    }
}
