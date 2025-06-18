using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class GuestTests
    {
        // Тест: корректный расчет стоимости аренды
        [TestMethod]
        public void Guest_CalculateCost_Normal()
        {
            var guest = new Guest { RentalMinutes = 60, Tariff = 3.0 };
            Assert.AreEqual(180.0, guest.CalculateCost());
        }

        // Тест: нулевая продолжительность
        [TestMethod]
        public void Guest_CalculateCost_ZeroMinutes()
        {
            var guest = new Guest { RentalMinutes = 0, Tariff = 5.0 };
            Assert.AreEqual(0.0, guest.CalculateCost());
        }

        // Тест: отрицательные значения
        [TestMethod]
        public void Guest_CalculateCost_NegativeValues()
        {
            var guest = new Guest { RentalMinutes = -10, Tariff = -2.0 };
            Assert.AreEqual(20.0, guest.CalculateCost());
        }

        // Тест: установка даты начала
        [TestMethod]
        public void Guest_SetStartTime()
        {
            var now = DateTime.Now;
            var guest = new Guest { StartTime = now };
            Assert.AreEqual(now, guest.StartTime);
        }

        // Тест: проверка установки места
        [TestMethod]
        public void Guest_SetSeatNumber()
        {
            var guest = new Guest { SeatNumber = 12 };
            Assert.AreEqual(12, guest.SeatNumber);
        }

        // Тест: установка тарифа
        [TestMethod]
        public void Guest_SetTariff()
        {
            var guest = new Guest { Tariff = 4.0 };
            Assert.AreEqual(4.0, guest.Tariff);
        }

        // Тест: имя и VIP статус
        [TestMethod]
        public void Guest_SetNameAndVIP()
        {
            var guest = new Guest { Name = "Ivan", IsVIP = true };
            Assert.AreEqual("Ivan", guest.Name);
            Assert.IsTrue(guest.IsVIP);
        }

        // Тест: отрицательный тариф
        [TestMethod]
        public void Guest_NegativeTariff()
        {
            var guest = new Guest { Tariff = -3.5 };
            Assert.AreEqual(-3.5, guest.Tariff);
        }

        // Тест: отрицательное время
        [TestMethod]
        public void Guest_NegativeMinutes()
        {
            var guest = new Guest { RentalMinutes = -45 };
            Assert.AreEqual(-45, guest.RentalMinutes);
        }

        // Тест: гость без имени
        [TestMethod]
        public void Guest_NullName()
        {
            var guest = new Guest { Name = null };
            Assert.IsNull(guest.Name);
        }
    }
}