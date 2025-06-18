using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp_Club
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Discount { get; set; }
        public string VIP_Level { get; set; }

        public string DisplayName => $"{Name} (ID: {ClientID})";
    }
}
