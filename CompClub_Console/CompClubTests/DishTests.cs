using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class DishTests
    {
        // Тест: корректное создание блюда
        [TestMethod]
        public void CreateDish_ValidData_ShouldSucceed()
        {
            var dish = new Dish { Name = "Burger", Category = "FastFood", Price = 5.99 };
            Assert.AreEqual("Burger", dish.Name);
            Assert.AreEqual("FastFood", dish.Category);
            Assert.AreEqual(5.99, dish.Price);
        }

        // Тест: блюдо с пустыми строками
        [TestMethod]
        public void Dish_EmptyNameAndCategory_ShouldBeAccepted()
        {
            var dish = new Dish { Name = "", Category = "" };
            Assert.AreEqual("", dish.Name);
            Assert.AreEqual("", dish.Category);
        }

        // Тест: нулевая цена блюда
        [TestMethod]
        public void Dish_ZeroPrice_ShouldBeAccepted()
        {
            var dish = new Dish { Price = 0 };
            Assert.AreEqual(0, dish.Price);
        }

        // Тест: отрицательная цена
        [TestMethod]
        public void Dish_NegativePrice_ShouldBeAccepted()
        {
            var dish = new Dish { Price = -1.5 };
            Assert.AreEqual(-1.5, dish.Price);
        }

        // Тест: длинное имя
        [TestMethod]
        public void Dish_LongName_ShouldBeAccepted()
        {
            string longName = new string('b', 500);
            var dish = new Dish { Name = longName };
            Assert.AreEqual(500, dish.Name.Length);
        }

        // Тест: спецсимволы в категории
        [TestMethod]
        public void Dish_SpecialCharsInCategory_ShouldBeAccepted()
        {
            var dish = new Dish { Category = "@#$%^" };
            Assert.AreEqual("@#$%^", dish.Category);
        }

        // Тест: null в имени
        [TestMethod]
        public void Dish_NullName_ShouldBeNull()
        {
            var dish = new Dish { Name = null };
            Assert.IsNull(dish.Name);
        }

        // Тест: null в категории
        [TestMethod]
        public void Dish_NullCategory_ShouldBeNull()
        {
            var dish = new Dish { Category = null };
            Assert.IsNull(dish.Category);
        }

        // Тест: большое значение цены
        [TestMethod]
        public void Dish_MaxDoublePrice_ShouldBeAccepted()
        {
            var dish = new Dish { Price = double.MaxValue };
            Assert.AreEqual(double.MaxValue, dish.Price);
        }

        // Тест: отсутствие инициализации
        [TestMethod]
        public void Dish_DefaultValues_ShouldBeZeroOrNull()
        {
            var dish = new Dish();
            Assert.IsNull(dish.Name);
            Assert.IsNull(dish.Category);
            Assert.AreEqual(0, dish.Price);
        }
    }
}