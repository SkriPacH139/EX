using System;

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
