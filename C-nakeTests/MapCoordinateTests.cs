using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using C_nake.Models;
using C_nake.Constants;

namespace C_nakeTests
{
    [TestClass]
    public class MapCoordinateTests
    {
        [TestMethod]
        public void CreateNewMapCoordinateTest()
        {
            int row = 4;
            int col = 4;
            MapCoordinate coord = new MapCoordinate(row, col);
            Assert.AreEqual(row, coord.Row);
            Assert.AreEqual(col, coord.Col);
        }

        [TestMethod]
        public void CreateNewRandomMapCoordinateTest()
        {
            Random rng = new Random();
            MapCoordinate coord = new MapCoordinate(rng);
            Assert.IsTrue(coord.Row >= 0 && coord.Row < MapDimensions.Rows);
            Assert.IsTrue(coord.Col >= 0 && coord.Col < MapDimensions.Cols);
        }

        [TestMethod]
        public void CreateNewMapCoordinateRowOutOfBoundsTest()
        {
            int rowTooSmall = -5;
            int rowTooBig = MapDimensions.Rows + 1;
            int col = 0;
            Assert.ThrowsException<ArgumentException>(() => new MapCoordinate(rowTooSmall, col));
            Assert.ThrowsException<ArgumentException>(() => new MapCoordinate(rowTooBig, col));
        }

        [TestMethod]
        public void CreateNewMapCoordinateColOutOfBoundsTest()
        {
            int row = 0;
            int colTooSmall = -5;
            int colTooBig = MapDimensions.Cols + 1;
            Assert.ThrowsException<ArgumentException>(() => new MapCoordinate(row, colTooSmall));
            Assert.ThrowsException<ArgumentException>(() => new MapCoordinate(row, colTooBig));
        }
    }
}
