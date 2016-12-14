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
        public long AnnouncementId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
