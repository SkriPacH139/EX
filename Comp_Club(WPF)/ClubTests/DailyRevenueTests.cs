using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Comp_Club;

namespace Comp_Club.Tests
{
    [TestClass]
    public class DailyRevenueTests
    {
        // Позитивный тест #1
        [TestMethod]
        public void DailyRevenue_PositiveTest1()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #2
        [TestMethod]
        public void DailyRevenue_PositiveTest2()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #3
        [TestMethod]
        public void DailyRevenue_PositiveTest3()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #4
        [TestMethod]
        public void DailyRevenue_PositiveTest4()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #5
        [TestMethod]
        public void DailyRevenue_PositiveTest5()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #6
        [TestMethod]
        public void DailyRevenue_PositiveTest6()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #7
        [TestMethod]
        public void DailyRevenue_PositiveTest7()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #8
        [TestMethod]
        public void DailyRevenue_PositiveTest8()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #9
        [TestMethod]
        public void DailyRevenue_PositiveTest9()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Позитивный тест #10
        [TestMethod]
        public void DailyRevenue_PositiveTest10()
        {
            // Создание объекта DailyRevenue с корректными данными
            var obj = new DailyRevenue
            {
                Id = 1,
                Category = "Category1",
                Revenue = 1000m
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Category1", obj.Category);
            Assert.AreEqual(1000m, obj.Revenue);
        }

        // Негативный тест #1
        [TestMethod]
        public void DailyRevenue_NegativeTest1()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Revenue = -100m;
            Assert.AreEqual(-100m, obj.Revenue);
        }

        // Негативный тест #2
        [TestMethod]
        public void DailyRevenue_NegativeTest2()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #3
        [TestMethod]
        public void DailyRevenue_NegativeTest3()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #4
        [TestMethod]
        public void DailyRevenue_NegativeTest4()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #5
        [TestMethod]
        public void DailyRevenue_NegativeTest5()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #6
        [TestMethod]
        public void DailyRevenue_NegativeTest6()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #7
        [TestMethod]
        public void DailyRevenue_NegativeTest7()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #8
        [TestMethod]
        public void DailyRevenue_NegativeTest8()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #9
        [TestMethod]
        public void DailyRevenue_NegativeTest9()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

        // Негативный тест #10
        [TestMethod]
        public void DailyRevenue_NegativeTest10()
        {
            // Тестирование некорректных значений
            var obj = new DailyRevenue();
            obj.Category = null;
            Assert.IsNull(obj.Category);
        }

    }
}