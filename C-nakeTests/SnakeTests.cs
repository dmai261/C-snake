using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using C_nake.Constants;
using C_nake.Models;
using C_nake.MapTiles;

namespace C_nakeTests
{
    [TestClass]
    public class SnakeTests
    {
        private Snake testSnake;

        [TestInitialize]
        public void Setup()
        {
            Map newmap = new Map();
            testSnake = new Snake(newmap);
        }
     

     
        [TestMethod]
        public void changeCurrentDiractionValidTest()
        {
            testSnake.CurrentDirection = ConsoleKey.LeftArrow;
            Assert.AreEqual(testSnake.CurrentDirection, ConsoleKey.LeftArrow);
        }

        [TestMethod]
        public void invalidKeyInputForDirection()
        {
            testSnake.CurrentDirection = ConsoleKey.W;
            Assert.AreNotEqual(testSnake.CurrentDirection, ConsoleKey.W);
        }

        [TestMethod]
        public void invalidDirectionInputTest()
        {
            testSnake.CurrentDirection = ConsoleKey.DownArrow;
            testSnake.CurrentDirection = ConsoleKey.UpArrow;
            Assert.AreNotEqual(testSnake.CurrentDirection, ConsoleKey.UpArrow);
        }

        

    }
}
