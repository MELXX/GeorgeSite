using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public string Content { get; set; }
        public string Address { get; set; }
        public string RecevierName { get; set; }
        public string Sentfrom { get; set; }
    }
}
