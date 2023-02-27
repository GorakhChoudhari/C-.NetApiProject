using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Models.Common
{
    public  class Developers
    {
       public  int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Address { get; set; }
        public string? city { get; set; }

        public int Experience { get; set; } 
        public long PhoneNUmber { get; set; }

    }
}
