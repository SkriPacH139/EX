using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompClub_Console
{
    public class Guest
    {
        public string Name { get; set; }
        public bool IsVIP { get; set; }
        public DateTime StartTime { get; set; }
        public int SeatNumber { get; set; }
        public double Tariff { get; set; }
        public int RentalMinutes { get; set; }

        public double CalculateCost() => RentalMinutes * Tariff;
    }
}
