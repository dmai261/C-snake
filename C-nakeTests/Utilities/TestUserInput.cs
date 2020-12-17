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

        public SimulateReadKey(ConsoleKey key)
        {
            this.keyPressed = key;
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
            SimulateReadKey simulation = new SimulateReadKey(ConsoleKey.UpArrow);
            ConsoleKey keyPressed = simulation.ReadKey().Key;
            Assert.AreEqual(keyPressed, ConsoleKey.UpArrow);
        }
        [TestMethod]
        public void ShouldReturnDownArrow()
        {
            SimulateReadKey simulation = new SimulateReadKey(ConsoleKey.DownArrow);
            ConsoleKey keyPressed = simulation.ReadKey().Key;
            Assert.AreEqual(keyPressed, ConsoleKey.DownArrow);
        }
        [TestMethod]
        public void ShouldReturnRightArrow()
        {
            SimulateReadKey simulation = new SimulateReadKey(ConsoleKey.RightArrow);
            ConsoleKey keyPressed = simulation.ReadKey().Key;
            Assert.AreEqual(keyPressed, ConsoleKey.RightArrow);
        }
        [TestMethod]
        public void ShouldReturnLeftArrow()
        {
            SimulateReadKey simulation = new SimulateReadKey(ConsoleKey.LeftArrow);
            ConsoleKey keyPressed = simulation.ReadKey().Key;
            Assert.AreEqual(keyPressed, ConsoleKey.LeftArrow);
        }

    }
}
