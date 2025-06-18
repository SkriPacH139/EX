using System;

namespace CompClub_Console
{
    /// Временный гость клуба, не зарегистрированный клиент.
    public class Guest
    {
        /// Имя гостя
        public string Name { get; set; } = "Гость";

        /// VIP-статус
        public bool IsVIP { get; set; }

        /// Время начала сессии
        public DateTime StartTime { get; set; } = DateTime.Now;

        /// Номер занятого места (0–9)
        public int SeatNumber { get; set; }

        /// Тариф за минуту
        public double Tariff { get; set; }

        /// Продолжительность аренды в минутах
        public int RentalMinutes { get; set; }

        /// Подсчёт стоимости аренды
        public double CalculateCost() => RentalMinutes * Tariff;

        public int Age { get; set; }
        public DateTime JoinTime { get; set; }

        public override string ToString()
        {
            return $"{Name} {(IsVIP ? "[VIP]" : "")} — {RentalMinutes} мин, место {SeatNumber}";
        }
    }
}