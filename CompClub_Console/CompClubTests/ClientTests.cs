using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class ClientTests
    {
        // Тест: корректное создание клиента
        [TestMethod]
        public void Client_Initialization()
        {
            var client = new Client
            {
                Name = "Maria",
                PhoneNumber = "123456789",
                AccumulatedBonus = 100.0,
                RegistrationDate = DateTime.Now,
                HasMembershipCard = true,
                Discount = 5.0
            };
            Assert.AreEqual("Maria", client.Name);
        }

        // Тест: отрицательная скидка
        [TestMethod]
        public void Client_NegativeDiscount()
        {
            var client = new Client { Discount = -10 };
            Assert.AreEqual(-10, client.Discount);
        }

        // Тест: отсутствие карты
        [TestMethod]
        public void Client_NoMembership()
        {
            var client = new Client { HasMembershipCard = false };
            Assert.IsFalse(client.HasMembershipCard);
        }

        // Тест: пустой телефон
        [TestMethod]
        public void Client_EmptyPhone()
        {
            var client = new Client { PhoneNumber = "" };
            Assert.AreEqual("", client.PhoneNumber);
        }

        // Тест: клиент без имени
        [TestMethod]
        public void Client_NullName()
        {
            var client = new Client { Name = null };
            Assert.IsNull(client.Name);
        }

        // Тест: бонус может быть отрицательным
        [TestMethod]
        public void Client_NegativeBonus()
        {
            var client = new Client { AccumulatedBonus = -50 };
            Assert.AreEqual(-50, client.AccumulatedBonus);
        }

        // Тест: большие бонусы
        [TestMethod]
        public void Client_MaxBonus()
        {
            var client = new Client { AccumulatedBonus = double.MaxValue };
            Assert.AreEqual(double.MaxValue, client.AccumulatedBonus);
        }

        // Тест: дата регистрации в прошлом
        [TestMethod]
        public void Client_RegistrationInPast()
        {
            var date = new DateTime(2000, 1, 1);
            var client = new Client { RegistrationDate = date };
            Assert.AreEqual(date, client.RegistrationDate);
        }

        // Тест: скидка 0
        [TestMethod]
        public void Client_ZeroDiscount()
        {
            var client = new Client { Discount = 0 };
            Assert.AreEqual(0, client.Discount);
        }

        // Тест: клиент по умолчанию
        [TestMethod]
        public void Client_DefaultConstructor()
        {
            var client = new Client();
            Assert.IsNull(client.Name);
            Assert.AreEqual(0, client.Discount);
        }
    }
}