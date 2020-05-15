using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Entities
{
    public class User
    {
        public int Id {get;set;}

        public string Name { get; set; }


        public string Surname { get; set; }
        public string address { get; set; }

        public string Email { get; set; }


        public string Phone { get; set; }
    }
}
