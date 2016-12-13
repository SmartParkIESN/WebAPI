using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reporting
    {
        [Key]
        public long ReportingId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public long AnnouncementId { get; set; }
        [Required]
        public Announcement Announce { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
