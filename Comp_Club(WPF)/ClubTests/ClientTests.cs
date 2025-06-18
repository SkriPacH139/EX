using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Comp_Club;

namespace Comp_Club.Tests
{
    [TestClass]
    public class ClientTests
    {
        // Позитивный тест #1
        [TestMethod]
        public void Client_PositiveTest1()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #2
        [TestMethod]
        public void Client_PositiveTest2()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #3
        [TestMethod]
        public void Client_PositiveTest3()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #4
        [TestMethod]
        public void Client_PositiveTest4()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #5
        [TestMethod]
        public void Client_PositiveTest5()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #6
        [TestMethod]
        public void Client_PositiveTest6()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #7
        [TestMethod]
        public void Client_PositiveTest7()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #8
        [TestMethod]
        public void Client_PositiveTest8()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #9
        [TestMethod]
        public void Client_PositiveTest9()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Позитивный тест #10
        [TestMethod]
        public void Client_PositiveTest10()
        {
            // Создание клиента с корректными данными
            var client = new Client
            {
                ClientID = 1,
                Name = "Maria",
                Phone = "123456789",
                Email = "maria@example.com",
                Discount = 0.1m,
                VIP_Level = "Gold"
            };
            // Проверка свойств
            Assert.AreEqual(1, client.ClientID);
            Assert.AreEqual("Maria", client.Name);
            Assert.AreEqual("123456789", client.Phone);
            Assert.AreEqual("maria@example.com", client.Email);
            Assert.AreEqual(0.1m, client.Discount);
            Assert.AreEqual("Gold", client.VIP_Level);
            // Проверка вычисляемого свойства DisplayName
            Assert.AreEqual("Maria (ID: 1)", client.DisplayName);
        }

        // Негативный тест #1
        [TestMethod]
        public void Client_NegativeTest1()
        {
            // Тестирование некорректных значений
            var client = new Client();
            client.Name = null;
            Assert.IsNull(client.Name);
        }

        // Негативный тест #2
        [TestMethod]
        public void Client_NegativeTest2()
        {
            // Тестирование некорректных значений
            var client = new Client();
            client.Phone = "";
            Assert.AreEqual(string.Empty, client.Phone);
        }

        // Негативный тест #3
        [TestMethod]
        public void Client_NegativeTest3()
        {
            // Тестирование некорректных значений
            var client = new Client();
            client.Email = "invalid_email";
            Assert.AreEqual("invalid_email", client.Email);
        }

        // Негативный тест #4
        [TestMethod]
        public void Client_NegativeTest4()
        {
            // Тестирование некорректных значений
            var client = new Client();
            client.Discount = -0.1m;
            Assert.AreEqual(-0.1m, client.Discount);
        }

        // Негативный тест #5
        [TestMethod]
        public void Client_NegativeTest5()
        {
            // Тестирование некорректных значений
            var client = new Client();
            client.Discount = 1.1m;
            Assert.AreEqual(1.1m, client.Discount);
        }

        // Негативный тест #6
        [TestMethod]
        public void Client_NegativeTest6()
        {
            // Тестирование некорректных значений
            var client = new Client();
            client.VIP_Level = null;
            Assert.IsNull(client.VIP_Level);
        }

        // Негативный тест #7
        [TestMethod]
        public void Client_NegativeTest7()
        {
            // Тестирование некорректных значений
            // Дополнительный негативный сценарий: некорректное свойство
            var client = new Client();
            client.ClientID = -1;
            Assert.AreEqual(-1, client.ClientID);
        }

        // Негативный тест #8
        [TestMethod]
        public void Client_NegativeTest8()
        {
            // Тестирование некорректных значений
            // Дополнительный негативный сценарий: некорректное свойство
            var client = new Client();
            client.ClientID = -1;
            Assert.AreEqual(-1, client.ClientID);
        }

        // Негативный тест #9
        [TestMethod]
        public void Client_NegativeTest9()
        {
            // Тестирование некорректных значений
            // Дополнительный негативный сценарий: некорректное свойство
            var client = new Client();
            client.ClientID = -1;
            Assert.AreEqual(-1, client.ClientID);
        }

        // Негативный тест #10
        [TestMethod]
        public void Client_NegativeTest10()
        {
            // Тестирование некорректных значений
            // Дополнительный негативный сценарий: некорректное свойство
            var client = new Client();
            client.ClientID = -1;
            Assert.AreEqual(-1, client.ClientID);
        }

    }
}