using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class ComponentTests
    {
        // Позитивные тесты

        // Тест: создание компонента с валидными значениями
        [TestMethod]
        public void CreateComponent_WithValidValues_ShouldSucceed()
        {
            var component = new Component { Name = "Flour", Category = "Baking", Quantity = 10, Price = 2.5 };
            Assert.AreEqual("Flour", component.Name);
            Assert.AreEqual("Baking", component.Category);
            Assert.AreEqual(10, component.Quantity);
            Assert.AreEqual(2.5, component.Price);
        }

        // Тест: установка количества = 0 допустима
        [TestMethod]
        public void CreateComponent_WithZeroQuantity_ShouldSucceed()
        {
            var component = new Component { Quantity = 0 };
            Assert.AreEqual(0, component.Quantity);
        }

        // Тест: отрицательное количество — допустимо, валидации нет
        [TestMethod]
        public void CreateComponent_WithNegativeQuantity_ShouldAcceptAsIs()
        {
            var component = new Component { Quantity = -5 };
            Assert.AreEqual(-5, component.Quantity);
        }

        // Тест: установка цены = 0 допустима
        [TestMethod]
        public void CreateComponent_WithZeroPrice_ShouldSucceed()
        {
            var component = new Component { Price = 0 };
            Assert.AreEqual(0, component.Price);
        }

        // Тест: отрицательная цена — допустима, валидации нет
        [TestMethod]
        public void CreateComponent_WithNegativePrice_ShouldAcceptAsIs()
        {
            var component = new Component { Price = -2.0 };
            Assert.AreEqual(-2.0, component.Price);
        }

        // Тест: имя компонента может быть null
        [TestMethod]
        public void CreateComponent_WithNullName_ShouldBeNull()
        {
            var component = new Component { Name = null };
            Assert.IsNull(component.Name);
        }

        // Тест: пустая строка в категории допустима
        [TestMethod]
        public void CreateComponent_WithEmptyCategory_ShouldBeEmpty()
        {
            var component = new Component { Category = "" };
            Assert.AreEqual("", component.Category);
        }

        // Тест: изменение свойств компонента после создания
        [TestMethod]
        public void ModifyComponentProperties_ShouldReflectChanges()
        {
            var component = new Component();
            component.Name = "Salt";
            component.Quantity = 3;
            Assert.AreEqual("Salt", component.Name);
            Assert.AreEqual(3, component.Quantity);
        }

        // Тест: максимально допустимое значение количества
        [TestMethod]
        public void CreateComponent_LargeQuantity_ShouldSucceed()
        {
            var component = new Component { Quantity = int.MaxValue };
            Assert.AreEqual(int.MaxValue, component.Quantity);
        }

        // Тест: максимально допустимое значение цены
        [TestMethod]
        public void CreateComponent_LargePrice_ShouldSucceed()
        {
            var component = new Component { Price = double.MaxValue };
            Assert.AreEqual(double.MaxValue, component.Price);
        }

        // Негативные тесты (не выбрасывают исключений, но логически странны)

        // Тест: категория может быть null
        [TestMethod]
        public void Negative_CreateComponent_NullCategory_ShouldBeNull()
        {
            var component = new Component { Category = null };
            Assert.IsNull(component.Category);
        }

        // Тест: пустая строка в имени компонента
        [TestMethod]
        public void Negative_CreateComponent_EmptyName_ShouldBeEmpty()
        {
            var component = new Component { Name = "" };
            Assert.AreEqual("", component.Name);
        }

        // Тест: установка отрицательных значений вручную
        [TestMethod]
        public void Negative_ModifyComponent_SetInvalidValues()
        {
            var component = new Component { Quantity = -1000, Price = -999.99 };
            Assert.IsTrue(component.Quantity < 0);
            Assert.IsTrue(component.Price < 0);
        }

        // Тест: спецсимволы в названии и категории
        [TestMethod]
        public void Negative_CreateComponent_WithSpecialCharacters()
        {
            var component = new Component { Name = "@#%$", Category = "^&*" };
            Assert.AreEqual("@#%$", component.Name);
            Assert.AreEqual("^&*", component.Category);
        }

        // Тест: частичная инициализация компонента
        [TestMethod]
        public void Negative_CreateComponent_PartialInitialization()
        {
            var component = new Component { Name = "OnlyName" };
            Assert.AreEqual("OnlyName", component.Name);
            Assert.AreEqual(0, component.Quantity); // по умолчанию
        }

        // Тест: инициализация компонента без параметров
        [TestMethod]
        public void Negative_CreateComponent_NoInitialization()
        {
            var component = new Component();
            Assert.IsNull(component.Name);
            Assert.AreEqual(0, component.Quantity);
        }

        // Тест: установка значения NaN для цены
        [TestMethod]
        public void Negative_SetComponent_PriceToNaN()
        {
            var component = new Component { Price = double.NaN };
            Assert.IsTrue(double.IsNaN(component.Price));
        }

        // Тест: установка минимального значения количества
        [TestMethod]
        public void Negative_SetComponent_QuantityToMinInt()
        {
            var component = new Component { Quantity = int.MinValue };
            Assert.AreEqual(int.MinValue, component.Quantity);
        }

        // Тест: имя, состоящее только из пробелов
        [TestMethod]
        public void Negative_SetComponent_NameToWhitespace()
        {
            var component = new Component { Name = "   " };
            Assert.AreEqual("   ", component.Name);
        }

        // Тест: слишком длинное имя компонента
        [TestMethod]
        public void Negative_SetComponent_TooLongName()
        {
            string longName = new string('a', 10000);
            var component = new Component { Name = longName };
            Assert.AreEqual(10000, component.Name.Length);
        }
    }
}
