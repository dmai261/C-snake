using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_nake.MapTiles;
using C_nake.Constants;

namespace C_nakeTests
{
    [TestClass]
    public class MapTileTests
    {
        [TestMethod]
        public void AppleTileTest()
        {
            AppleTile tile = new AppleTile();
            Assert.AreEqual(MapTileSymbols.Apple, tile.Symbol);
            Assert.AreEqual(MapTileColors.Apple, tile.Color);
        }

        [TestMethod]
        public void BlankTileTest()
        {
            BlankTile tile = new BlankTile();
            Assert.AreEqual(MapTileSymbols.Blank, tile.Symbol);
            Assert.AreEqual(MapTileColors.Blank, tile.Color);
        }

        [TestMethod]
        public void BottomWallTileTest()
        {
            BottomWallTile tile = new BottomWallTile();
            Assert.AreEqual(MapTileSymbols.BottomWall, tile.Symbol);
            Assert.AreEqual(MapTileColors.BottomWall, tile.Color);
        }

        [TestMethod]
        public void SideWallTileTest()
        {
            SideWallTile tile = new SideWallTile();
            Assert.AreEqual(MapTileSymbols.SideWall, tile.Symbol);
            Assert.AreEqual(MapTileColors.SideWall, tile.Color);
        }

        [TestMethod]
        public void SnakeBodyTileTest()
        {
            SnakeBodyTile tile = new SnakeBodyTile();
            Assert.AreEqual(MapTileSymbols.SnakeBody, tile.Symbol);
            Assert.AreEqual(MapTileColors.SnakeBody, tile.Color);
        }

        [TestMethod]
        public void SnakeHeadTileTest()
        {
            SnakeHeadTile tile = new SnakeHeadTile();
            Assert.AreEqual(MapTileSymbols.SnakeHead, tile.Symbol);
            Assert.AreEqual(MapTileColors.SnakeHead, tile.Color);
        }

        [TestMethod]
        public void TopWallTileTest()
        {
            TopWallTile tile = new TopWallTile();
            Assert.AreEqual(MapTileSymbols.TopWall, tile.Symbol);
            Assert.AreEqual(MapTileColors.TopWall, tile.Color);
        }
    }
}
