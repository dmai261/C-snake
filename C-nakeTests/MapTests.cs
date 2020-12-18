using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using C_nake.Constants;
using C_nake.Models;
using C_nake.MapTiles;

namespace C_nakeTests
{
    [TestClass]
    public class MapTests
    {
        private Map map;

        [TestInitialize]
        public void Setup()
        {
            map = new Map();
        }

        [TestMethod]
        public void GetTileTest()
        {
            MapCoordinate topWallCoord = new MapCoordinate(0, 0);
            MapCoordinate sideWallCoord = new MapCoordinate(1, 0);
            MapCoordinate bottomWallCoord = new MapCoordinate(MapDimensions.Rows - 1, 0);
            MapCoordinate blankCoord = new MapCoordinate(1, 1);

            Assert.IsTrue(map.GetTile(topWallCoord) is TopWallTile);
            Assert.IsTrue(map.GetTile(sideWallCoord) is SideWallTile);
            Assert.IsTrue(map.GetTile(bottomWallCoord) is BottomWallTile);
            Assert.IsTrue(map.GetTile(blankCoord) is BlankTile);
        }

        [TestMethod]
        public void ChangeTileTest()
        {
            MapCoordinate coord = new MapCoordinate(1, 1);
            SnakeHeadTile head = new SnakeHeadTile();
            map.ChangeTile(coord, head);

            Assert.AreEqual(map.GetTile(coord), head);
        }

        [TestMethod]
        public void ChangeTileCanNotChangeWallTiles()
        {
            MapCoordinate wallCoord = new MapCoordinate(0, 0);
            SnakeBodyTile body = new SnakeBodyTile();

            Assert.ThrowsException<ArgumentException>(() => map.ChangeTile(wallCoord, body));
        }

        [TestMethod]
        public void GenerateAppleTest()
        {
            map.GenerateApple();
            Assert.IsTrue(findApple());
        }

        private bool findApple()
        {
            for (int row = 1; row < MapDimensions.Rows - 1; row++)
            {
                for (int col = 1; col < MapDimensions.Cols - 1; col++)
                {
                    MapCoordinate coord = new MapCoordinate(row, col);
                    if (map.GetTile(coord) is AppleTile)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
