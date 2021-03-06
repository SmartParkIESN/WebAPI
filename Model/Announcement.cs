﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public Boolean Rented { get; set; }
        public int ParkingId { get; set; }
        [ForeignKey("ParkingId")]
        public Parking parking { get; set; }
    }
}
