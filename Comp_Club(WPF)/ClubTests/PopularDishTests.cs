using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Comp_Club;

namespace Comp_Club.Tests
{
    [TestClass]
    public class PopularDishTests
    {
        // Позитивный тест #1
        [TestMethod]
        public void PopularDish_PositiveTest1()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #2
        [TestMethod]
        public void PopularDish_PositiveTest2()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #3
        [TestMethod]
        public void PopularDish_PositiveTest3()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #4
        [TestMethod]
        public void PopularDish_PositiveTest4()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #5
        [TestMethod]
        public void PopularDish_PositiveTest5()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #6
        [TestMethod]
        public void PopularDish_PositiveTest6()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #7
        [TestMethod]
        public void PopularDish_PositiveTest7()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #8
        [TestMethod]
        public void PopularDish_PositiveTest8()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #9
        [TestMethod]
        public void PopularDish_PositiveTest9()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Позитивный тест #10
        [TestMethod]
        public void PopularDish_PositiveTest10()
        {
            // Создание объекта PopularDish с корректными данными
            var obj = new PopularDish
            {
                Id = 1,
                DishName = "Dish1",
                OrderCount = 50
            };
            // Проверка свойств
            Assert.AreEqual(1, obj.Id);
            Assert.AreEqual("Dish1", obj.DishName);
            Assert.AreEqual(50, obj.OrderCount);
        }

        // Негативный тест #1
        [TestMethod]
        public void PopularDish_NegativeTest1()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #2
        [TestMethod]
        public void PopularDish_NegativeTest2()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #3
        [TestMethod]
        public void PopularDish_NegativeTest3()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #4
        [TestMethod]
        public void PopularDish_NegativeTest4()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #5
        [TestMethod]
        public void PopularDish_NegativeTest5()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #6
        [TestMethod]
        public void PopularDish_NegativeTest6()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #7
        [TestMethod]
        public void PopularDish_NegativeTest7()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #8
        [TestMethod]
        public void PopularDish_NegativeTest8()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #9
        [TestMethod]
        public void PopularDish_NegativeTest9()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

        // Негативный тест #10
        [TestMethod]
        public void PopularDish_NegativeTest10()
        {
            // Тестирование некорректных значений
            var obj = new PopularDish();
            // Отсутствует встроенная валидация, проверяется присвоение некорректного значения
            obj.DishName = null;
            Assert.IsNull(obj.DishName);
        }

    }
}