using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class ProgramTests
    {
        // ����: ����� Main �� ������ ����������� ���������� ��� ������� ��� ����������
        [TestMethod]
        public void Main_DoesNotThrow()
        {
            try
            {
                CompClub_Console.Program.Main(new string[] { });
            }
            catch (Exception ex)
            {
                Assert.Fail("���������� ��� ���������� Main: " + ex.Message);
            }
        }

        // ����: ����� Program �������� ����� Main
        [TestMethod]
        public void Program_HasMainMethod()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.IsNotNull(method);
        }

        // ����: ����� Main ������ ���� �����������
        [TestMethod]
        public void Program_MainMethod_IsStatic()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.IsTrue(method.IsStatic);
        }

        // ����: ����� Main ������ ��������� ������ ����� ��� ��������
        [TestMethod]
        public void Program_Main_AcceptsArgs()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.AreEqual(1, method.GetParameters().Length);
        }

        // ����: ����� Main �� ������ ���������� �������� (void)
        [TestMethod]
        public void Program_Main_ReturnsVoid()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.AreEqual(typeof(void), method.ReturnType);
        }

        // ����: ����� Main ������ ��������� ������������ ��� null � ����������
        [TestMethod]
        public void Program_Main_RunsSafelyWithNullArgs()
        {
            try
            {
                CompClub_Console.Program.Main(null);
            }
            catch (Exception ex)
            {
                Assert.Fail("���������� ��� �������� null � Main: " + ex.Message);
            }
        }

        // ����: ����� Main ������ ��������� ������������ ��� ������� ����������
        [TestMethod]
        public void Program_Main_WithArguments_DoesNotThrow()
        {
            try
            {
                CompClub_Console.Program.Main(new[] { "arg1", "arg2" });
            }
            catch (Exception ex)
            {
                Assert.Fail("���������� ��� �������� ���������� � Main: " + ex.Message);
            }
        }

        // ����: ������� ������ Program � ��������� ������������ ���
        [TestMethod]
        public void Program_Class_Exists()
        {
            var type = Type.GetType("CompClub_Console.Program");
            Assert.IsNotNull(type);
        }

        // ����: ����� Main ������ ���� ���������
        [TestMethod]
        public void Program_MainMethod_IsPublic()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.IsTrue(method.IsPublic);
        }

        // ����: ��������� ������ Main ������������� ��������
        [TestMethod]
        public void Program_MainMethod_HasExpectedSignature()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.AreEqual("Void Main(System.String[])", method.ToString());
        }
    }
}
