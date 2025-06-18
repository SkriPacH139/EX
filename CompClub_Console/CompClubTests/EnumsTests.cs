using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompClub_Console;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class EnumsTests
    {
        // ����: �������� ������������ InProcess ������ ���� 0
        [TestMethod]
        public void OrderStatus_InProcess_ShouldBeZero()
        {
            Assert.AreEqual(0, (int)OrderStatus.InProcess);
        }

        // ����: �������� ������������ Ready ������ ���� 1
        [TestMethod]
        public void OrderStatus_Ready_ShouldBeOne()
        {
            Assert.AreEqual(1, (int)OrderStatus.Ready);
        }

        // ����: �������� ������������ Delivered ������ ���� 2
        [TestMethod]
        public void OrderStatus_Delivered_ShouldBeTwo()
        {
            Assert.AreEqual(2, (int)OrderStatus.Delivered);
        }

        // ����: ����� ToString() ���������� ������ ��������������� �������� ������������
        [TestMethod]
        public void Enum_ToString_ReturnsCorrectName()
        {
            Assert.AreEqual("Ready", OrderStatus.Ready.ToString());
        }

        // ����: ���������� �������������� ������ � �������� ������������
        [TestMethod]
        public void Enum_ParseFromString_Success()
        {
            var status = (OrderStatus)System.Enum.Parse(typeof(OrderStatus), "Delivered");
            Assert.AreEqual(OrderStatus.Delivered, status);
        }

        // ����: ����� �������������� ������������ � int
        [TestMethod]
        public void Enum_ConvertToInt()
        {
            int value = (int)OrderStatus.Ready;
            Assert.AreEqual(1, value);
        }

        // ����: ������� ������������� �������������� �������� �������� ����������
        [TestMethod]
        public void Enum_InvalidParse_Throws()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
                System.Enum.Parse(typeof(OrderStatus), "Unknown"));
        }

        // ����: �������� ������������� �������� � ������������ (��������)
        [TestMethod]
        public void Enum_IsDefined_CheckValid()
        {
            Assert.IsTrue(System.Enum.IsDefined(typeof(OrderStatus), "InProcess"));
        }

        // ����: �������� ������������� �������� � ������������ (����������)
        [TestMethod]
        public void Enum_IsDefined_CheckInvalid()
        {
            Assert.IsFalse(System.Enum.IsDefined(typeof(OrderStatus), "Cancelled"));
        }

        // ����: ������������ �������� ��������� ���������� ��������
        [TestMethod]
        public void Enum_HasExpectedCount()
        {
            var values = System.Enum.GetValues(typeof(OrderStatus));
            Assert.AreEqual(3, values.Length);
        }
    }
}
