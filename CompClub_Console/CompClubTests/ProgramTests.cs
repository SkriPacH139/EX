using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompClub_Console.Tests
{
    [TestClass]
    public class ProgramTests
    {
        // Тест: метод Main не должен выбрасывать исключение при запуске без аргументов
        [TestMethod]
        public void Main_DoesNotThrow()
        {
            try
            {
                CompClub_Console.Program.Main(new string[] { });
            }
            catch (Exception ex)
            {
                Assert.Fail("Исключение при выполнении Main: " + ex.Message);
            }
        }

        // Тест: класс Program содержит метод Main
        [TestMethod]
        public void Program_HasMainMethod()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.IsNotNull(method);
        }

        // Тест: метод Main должен быть статическим
        [TestMethod]
        public void Program_MainMethod_IsStatic()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.IsTrue(method.IsStatic);
        }

        // Тест: метод Main должен принимать массив строк как аргумент
        [TestMethod]
        public void Program_Main_AcceptsArgs()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.AreEqual(1, method.GetParameters().Length);
        }

        // Тест: метод Main не должен возвращать значение (void)
        [TestMethod]
        public void Program_Main_ReturnsVoid()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.AreEqual(typeof(void), method.ReturnType);
        }

        // Тест: метод Main должен корректно отрабатывать при null в аргументах
        [TestMethod]
        public void Program_Main_RunsSafelyWithNullArgs()
        {
            try
            {
                CompClub_Console.Program.Main(null);
            }
            catch (Exception ex)
            {
                Assert.Fail("Исключение при передаче null в Main: " + ex.Message);
            }
        }

        // Тест: метод Main должен корректно отрабатывать при наличии аргументов
        [TestMethod]
        public void Program_Main_WithArguments_DoesNotThrow()
        {
            try
            {
                CompClub_Console.Program.Main(new[] { "arg1", "arg2" });
            }
            catch (Exception ex)
            {
                Assert.Fail("Исключение при передаче аргументов в Main: " + ex.Message);
            }
        }

        // Тест: наличие класса Program в указанном пространстве имён
        [TestMethod]
        public void Program_Class_Exists()
        {
            var type = Type.GetType("CompClub_Console.Program");
            Assert.IsNotNull(type);
        }

        // Тест: метод Main должен быть публичным
        [TestMethod]
        public void Program_MainMethod_IsPublic()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.IsTrue(method.IsPublic);
        }

        // Тест: сигнатура метода Main соответствует ожиданию
        [TestMethod]
        public void Program_MainMethod_HasExpectedSignature()
        {
            var method = typeof(CompClub_Console.Program).GetMethod("Main");
            Assert.AreEqual("Void Main(System.String[])", method.ToString());
        }
    }
}
