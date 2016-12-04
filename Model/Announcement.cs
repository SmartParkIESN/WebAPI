using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Announcement
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Boolean Rented { get; set; }
        public Parking Parking { get; set; }
        public User User { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
