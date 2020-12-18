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
        private Map testMap;
        private Snake testSnake;

        [TestInitialize]
        public void Setup()
        {
            testMap = new Map();
            testSnake = new Snake(testMap);
        }
     
        [TestMethod]
        public void ChangeCurrentDiractionValidTest()
        {
            testSnake.CurrentDirection = ConsoleKey.LeftArrow;
            Assert.AreEqual(testSnake.CurrentDirection, ConsoleKey.LeftArrow);
        }

        [TestMethod]
        public void InvalidKeyInputForDirection()
        {
            testSnake.CurrentDirection = ConsoleKey.W;
            Assert.AreNotEqual(testSnake.CurrentDirection, ConsoleKey.W);
        }

        [TestMethod]
        public void InvalidDirectionInputTest()
        {
            testSnake.CurrentDirection = ConsoleKey.DownArrow;
            testSnake.CurrentDirection = ConsoleKey.UpArrow;
            Assert.AreNotEqual(testSnake.CurrentDirection, ConsoleKey.UpArrow);
        }

        [TestMethod]
        public void MoveTest()
        {
            int score = 0;
            MapCoordinate startingHeadCoord = InitialSnake.InitialBody[0];
            MapCoordinate nextHeadCoord = new MapCoordinate(startingHeadCoord.Row + 1, startingHeadCoord.Col);
            testSnake.CurrentDirection = ConsoleKey.DownArrow;

            Assert.IsTrue(testSnake.Move(ref score));
            Assert.IsTrue(testMap.GetTile(startingHeadCoord) is SnakeBodyTile);
            Assert.IsTrue(testMap.GetTile(nextHeadCoord) is SnakeHeadTile);
            Assert.AreEqual(score, GameConstants.AppleScore);
        }
    }
}
