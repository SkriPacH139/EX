using System;

namespace CompClub_Console
{
    public class Guest : Person
    {
        public DateTime StartTime { get; set; }
        public int SeatNumber { get; set; }
        public double Tariff { get; set; }
        public int RentalMinutes { get; set; }

        public double CalculateCost() => RentalMinutes * Tariff;
        
    }
}
