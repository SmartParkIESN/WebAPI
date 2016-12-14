using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        [Required]
        public string Pseudo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
