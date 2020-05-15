using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }
        public int OnHand { get; set; }

        public double Price { get; set; }

        public int Vendor { get; set; }

        public byte[] Image { get; set; }

        public string ImageUrl { get; set; }
    }
}
