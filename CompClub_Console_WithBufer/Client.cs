using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompClub_Console
{
    public class Client : Person
    {
        public string PhoneNumber { get; set; }
        public double AccumulatedBonus { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool HasMembershipCard { get; set; }
        public double Discount { get; set; }
    }
}
