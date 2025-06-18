using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class OrderTests
    {
        // Тест: корректное создание заказа
        [TestMethod]
        public void Order_Creation_ValidData()
        {
            var dish = new Dish { Name = "Pizza", Price = 10 };
            var order = new Order { ClientName = "Alex", OrderNumber = 1, SelectedDish = dish, Status = OrderStatus.InProcess };

            Assert.AreEqual("Alex", order.ClientName);
            Assert.AreEqual(1, order.OrderNumber);
            Assert.AreEqual(dish, order.SelectedDish);
            Assert.AreEqual(OrderStatus.InProcess, order.Status);
        }

        // Тест: изменение статуса заказа
        [TestMethod]
        public void Order_Status_CanChange()
        {
            var order = new Order { Status = OrderStatus.Ready };
            order.Status = OrderStatus.Delivered;
            Assert.AreEqual(OrderStatus.Delivered, order.Status);
        }

        // Тест: заказ без блюда
        [TestMethod]
        public void Order_NullDish_ShouldBeAccepted()
        {
            var order = new Order { SelectedDish = null };
            Assert.IsNull(order.SelectedDish);
        }

        // Тест: нулевая цена через блюдо
        [TestMethod]
        public void Order_ZeroDishPrice()
        {
            var dish = new Dish { Price = 0 };
            var order = new Order { SelectedDish = dish };
            Assert.AreEqual(0, order.SelectedDish.Price);
        }

        // Тест: имя клиента пустое
        [TestMethod]
        public void Order_EmptyClientName()
        {
            var order = new Order { ClientName = "" };
            Assert.AreEqual("", order.ClientName);
        }

        // Тест: отрицательный номер заказа
        [TestMethod]
        public void Order_NegativeNumber()
        {
            var order = new Order { OrderNumber = -99 };
            Assert.AreEqual(-99, order.OrderNumber);
        }

        // Тест: проверка инициализации по умолчанию
        [TestMethod]
        public void Order_DefaultValues()
        {
            var order = new Order();
            Assert.IsNull(order.ClientName);
            Assert.AreEqual(0, order.OrderNumber);
            Assert.AreEqual(OrderStatus.InProcess, order.Status);
        }

        // Тест: установка всех свойств
        [TestMethod]
        public void Order_SetAllProperties()
        {
            var dish = new Dish { Name = "Soup" };
            var order = new Order
            {
                ClientName = "Sam",
                OrderNumber = 11,
                SelectedDish = dish,
                Status = OrderStatus.Ready
            };
            Assert.AreEqual("Sam", order.ClientName);
        }

        // Тест: null в имени клиента
        [TestMethod]
        public void Order_NullClientName()
        {
            var order = new Order { ClientName = null };
            Assert.IsNull(order.ClientName);
        }

        // Тест: null объект Order
        [TestMethod]
        public void Order_NullObject_ShouldBeNull()
        {
            Order order = null;
            Assert.IsNull(order);
        }
    }
}