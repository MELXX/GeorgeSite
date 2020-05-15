using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public double Amount  { get; set; }
        public int UserId { get; set; }
        public double Tax { get; set; }

    }
}
