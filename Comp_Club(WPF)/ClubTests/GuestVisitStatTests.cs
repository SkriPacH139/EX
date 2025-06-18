using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Comp_Club;

namespace Comp_Club.Tests
{
    [TestClass]
    public class GuestVisitStatTests
    {
        // Позитивный тест #1
        [TestMethod]
        public void GuestVisitStat_PositiveTest1()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #2
        [TestMethod]
        public void GuestVisitStat_PositiveTest2()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #3
        [TestMethod]
        public void GuestVisitStat_PositiveTest3()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #4
        [TestMethod]
        public void GuestVisitStat_PositiveTest4()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #5
        [TestMethod]
        public void GuestVisitStat_PositiveTest5()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #6
        [TestMethod]
        public void GuestVisitStat_PositiveTest6()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #7
        [TestMethod]
        public void GuestVisitStat_PositiveTest7()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #8
        [TestMethod]
        public void GuestVisitStat_PositiveTest8()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #9
        [TestMethod]
        public void GuestVisitStat_PositiveTest9()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Позитивный тест #10
        [TestMethod]
        public void GuestVisitStat_PositiveTest10()
        {
            // Создание объекта GuestVisitStat с корректными данными
            var obj = new GuestVisitStat
            {
                Id = 1,
                Period = "2025-06",
                Visits = 30
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("2025-06", obj.Period);
            Assert.AreEqual(30, obj.Visits);
        }

        // Негативный тест #1
        [TestMethod]
        public void GuestVisitStat_NegativeTest1()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #2
        [TestMethod]
        public void GuestVisitStat_NegativeTest2()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #3
        [TestMethod]
        public void GuestVisitStat_NegativeTest3()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #4
        [TestMethod]
        public void GuestVisitStat_NegativeTest4()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #5
        [TestMethod]
        public void GuestVisitStat_NegativeTest5()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #6
        [TestMethod]
        public void GuestVisitStat_NegativeTest6()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #7
        [TestMethod]
        public void GuestVisitStat_NegativeTest7()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #8
        [TestMethod]
        public void GuestVisitStat_NegativeTest8()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #9
        [TestMethod]
        public void GuestVisitStat_NegativeTest9()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

        // Негативный тест #10
        [TestMethod]
        public void GuestVisitStat_NegativeTest10()
        {
            // Тестирование некорректных значений
            var obj = new GuestVisitStat();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.Period = null;
            Assert.IsNull(obj.Period);
        }

    }
}