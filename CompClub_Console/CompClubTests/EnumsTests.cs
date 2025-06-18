using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class EnumsTests
    {
        // “ест: значение перечислени€ InProcess должно быть 0
        [TestMethod]
        public void OrderStatus_InProcess_ShouldBeZero()
        {
            Assert.AreEqual(0, (int)OrderStatus.InProcess);
        }

        // “ест: значение перечислени€ Ready должно быть 1
        [TestMethod]
        public void OrderStatus_Ready_ShouldBeOne()
        {
            Assert.AreEqual(1, (int)OrderStatus.Ready);
        }

        // “ест: значение перечислени€ Delivered должно быть 2
        [TestMethod]
        public void OrderStatus_Delivered_ShouldBeTwo()
        {
            Assert.AreEqual(2, (int)OrderStatus.Delivered);
        }

        // “ест: метод ToString() возвращает строку соответствующую значению перечислени€
        [TestMethod]
        public void Enum_ToString_ReturnsCorrectName()
        {
            Assert.AreEqual("Ready", OrderStatus.Ready.ToString());
        }

        // “ест: корректное преобразование строки в значение перечислени€
        [TestMethod]
        public void Enum_ParseFromString_Success()
        {
            var status = (OrderStatus)System.Enum.Parse(typeof(OrderStatus), "Delivered");
            Assert.AreEqual(OrderStatus.Delivered, status);
        }

        // “ест: €вное преобразование перечислени€ в int
        [TestMethod]
        public void Enum_ConvertToInt()
        {
            int value = (int)OrderStatus.Ready;
            Assert.AreEqual(1, value);
        }

        // “ест: попытка преобразовать несуществующее значение вызывает исключение
        [TestMethod]
        public void Enum_InvalidParse_Throws()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
                System.Enum.Parse(typeof(OrderStatus), "Unknown"));
        }

        // “ест: проверка существовани€ значени€ в перечислении (валидное)
        [TestMethod]
        public void Enum_IsDefined_CheckValid()
        {
            Assert.IsTrue(System.Enum.IsDefined(typeof(OrderStatus), "InProcess"));
        }

        // “ест: проверка существовани€ значени€ в перечислении (невалидное)
        [TestMethod]
        public void Enum_IsDefined_CheckInvalid()
        {
            Assert.IsFalse(System.Enum.IsDefined(typeof(OrderStatus), "Cancelled"));
        }

        // “ест: перечисление содержит ожидаемое количество значений
        [TestMethod]
        public void Enum_HasExpectedCount()
        {
            var values = System.Enum.GetValues(typeof(OrderStatus));
            Assert.AreEqual(3, values.Length);
        }
    }
}
