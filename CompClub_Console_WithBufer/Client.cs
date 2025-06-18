using System;

namespace CompClub_Console
{
    /// Зарегистрированный клиент клуба.    
    public class Client : Person
    {
        //>Телефон клиента
        public string PhoneNumber { get; set; } = "";

        //>Накопленные бонусы
        public double AccumulatedBonus { get; set; }

        //>Дата регистрации
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        //>Есть ли карта постоянного клиента
        public bool HasMembershipCard { get; set; }

        //>Размер персональной скидки (%)
        public double Discount { get; set; }

        public override string ToString()
        {
            return $"{Name} ({PhoneNumber}) - Бонусы: {AccumulatedBonus}, Скидка: {Discount}%";
        }
    }
}