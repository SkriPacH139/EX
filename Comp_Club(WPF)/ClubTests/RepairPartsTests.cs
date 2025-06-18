using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Comp_Club;

namespace Comp_Club.Tests
{
    [TestClass]
    public class RepairPartsTests
    {
        // Позитивный тест #1
        [TestMethod]
        public void RepairParts_PositiveTest1()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #2
        [TestMethod]
        public void RepairParts_PositiveTest2()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #3
        [TestMethod]
        public void RepairParts_PositiveTest3()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #4
        [TestMethod]
        public void RepairParts_PositiveTest4()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #5
        [TestMethod]
        public void RepairParts_PositiveTest5()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #6
        [TestMethod]
        public void RepairParts_PositiveTest6()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #7
        [TestMethod]
        public void RepairParts_PositiveTest7()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #8
        [TestMethod]
        public void RepairParts_PositiveTest8()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #9
        [TestMethod]
        public void RepairParts_PositiveTest9()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Позитивный тест #10
        [TestMethod]
        public void RepairParts_PositiveTest10()
        {
            // Создание объекта RepairParts с корректными данными
            var obj = new RepairParts
            {
                Id = 1,
                PartsName = "Part1",
                Balance = 5
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Part1", obj.PartsName);
            Assert.AreEqual(5, obj.Balance);
        }

        // Негативный тест #1
        [TestMethod]
        public void RepairParts_NegativeTest1()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #2
        [TestMethod]
        public void RepairParts_NegativeTest2()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #3
        [TestMethod]
        public void RepairParts_NegativeTest3()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #4
        [TestMethod]
        public void RepairParts_NegativeTest4()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #5
        [TestMethod]
        public void RepairParts_NegativeTest5()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #6
        [TestMethod]
        public void RepairParts_NegativeTest6()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #7
        [TestMethod]
        public void RepairParts_NegativeTest7()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #8
        [TestMethod]
        public void RepairParts_NegativeTest8()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #9
        [TestMethod]
        public void RepairParts_NegativeTest9()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

        // Негативный тест #10
        [TestMethod]
        public void RepairParts_NegativeTest10()
        {
            // Тестирование некорректных значений
            var obj = new RepairParts();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.PartsName = null;
            Assert.IsNull(obj.PartsName);
        }

    }
}