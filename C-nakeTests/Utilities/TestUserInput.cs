using System;
using System.Collections.Generic;
using System.Text;
using C_nake.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_nake.Interfaces;
using System.Runtime.InteropServices.ComTypes;

namespace C_nakeTests.Utilities
{
    /// <summary>
    /// Simulating the readKey method
    /// </summary>
    public class SimulateReadKey : IConsoleWrapper
    {
        ConsoleKey keyPressed;
        
        public SimulateReadKey(ConsoleKey input)
        {
            keyPressed = input;
        }

        public ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo dummy = new ConsoleKeyInfo((char)(' '), keyPressed, false, false, false);
            return dummy;
        }
    }

    [TestClass]
    public class TestUserInput
    {
        [TestMethod]
        public void ShouldReturnUpArrow()
        {
            SimulateReadKey readMyKeyTest = new SimulateReadKey(ConsoleKey.UpArrow);
            UserInput myInputTest = new UserInput(readMyKeyTest);
            var actual = myInputTest.GetMove();
            var expected = ConsoleKey.UpArrow;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldReturnDownArrow()
        {
            SimulateReadKey readMyKeyTest = new SimulateReadKey(ConsoleKey.DownArrow);
            UserInput myInputTest = new UserInput(readMyKeyTest);
            var actual = myInputTest.GetMove();
            var expected = ConsoleKey.DownArrow;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldReturnRightArrow()
        {
            SimulateReadKey readMyKeyTest = new SimulateReadKey(ConsoleKey.RightArrow);
            UserInput myInputTest = new UserInput(readMyKeyTest);
            var actual = myInputTest.GetMove();
            var expected = ConsoleKey.RightArrow;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldReturnLeftArrow()
        {
            SimulateReadKey readMyKeyTest = new SimulateReadKey(ConsoleKey.LeftArrow);
            UserInput myInputTest = new UserInput(readMyKeyTest);
            var actual = myInputTest.GetMove();
            var expected = ConsoleKey.LeftArrow;
            Assert.AreEqual(actual, expected);
        }

    }
}
