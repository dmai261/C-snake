using System;
using C_nake.MapTiles;
using C_nake.Constants;
using C_nake.Interfaces;

namespace C_nake.Models
{
    public class Map : IDrawable
    {
        private Tile[][] map;
        private Random rng;

        public Map()
        {
            rng = new Random();
            initializeMap();
        }

        /// <summary>
        /// Helper method for initializing map state.
        /// </summary>
        private void initializeMap()
        {
            int lastRow = MapDimensions.Rows - 1;
            map = new Tile[MapDimensions.Rows][];

            initializeFullRow(0, new TopWallTile());
            for (int row = 1; row < lastRow; row++)
            {
                initializeMiddleRow(row);
            }
            initializeFullRow(lastRow, new BottomWallTile());
        }

        /// <summary>
        /// Helper method to initialize a full row of the same tile.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="tile">The type of tile to fill.</param>
        private void initializeFullRow(int row, Tile tile)
        {

            map[row] = new Tile[MapDimensions.Cols];
            for (int col = 0; col < MapDimensions.Cols; col++)
            {
                map[row][col] = tile;
            }
        }

        /// <summary>
        /// Helper method to build a middle row on map.
        /// </summary>
        /// <param name="row">The row number.</param>
        private void initializeMiddleRow(int row)
        {
            int firstCol = 0;
            int lastCol = MapDimensions.Cols - 1;

            map[row] = new Tile[MapDimensions.Cols];
            map[row][firstCol] = new SideWallTile();
            for (int col = 1; col < lastCol; col++)
            {
                map[row][col] = new BlankTile();
            }
            map[row][lastCol] = new SideWallTile();
        }

        /// <summary>
        /// Method for drawing the map to the console.
        /// </summary>
        public void Draw()
        {

            foreach (var row in map)
            {
                foreach (var tile in row)
                {
                    tile.Draw();
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets a tile located at specified MapCoordinate.
        /// </summary>
        /// <param name="coord">MapCoordinate where desired tile is located.</param>
        /// <returns>The tile at the coordinate.</returns>
        public Tile GetTile(MapCoordinate coord)
        {
            return map[coord.Row][coord.Col];
        }

        /// <summary>
        /// Changes a tile at given coordinate.
        /// </summary>
        /// <param name="coord">The coordinate where new tile will go.</param>
        /// <param name="newTile">The new tile to place at coordinate.</param>
        /// <exception cref="System.ArgumentException">Thrown if trying to change a wall tile.</exception>
        public void ChangeTile(MapCoordinate coord, Tile newTile)
        {
            Tile currentTile = GetTile(coord);
            bool isSideWallTile = currentTile is SideWallTile;
            bool isTopWallTile = currentTile is TopWallTile;
            bool isBottomWallTile = currentTile is BottomWallTile;

            if (isSideWallTile || isTopWallTile || isBottomWallTile)
            {
                throw new ArgumentException("Can not change wall tiles.");
            }

            map[coord.Row][coord.Col] = newTile;
        }

        /// <summary>
        /// Generates a new apple to add to the map. Apple can only be placed on blank tiles.
        /// </summary>
        public void GenerateApple()
        {
            MapCoordinate randomCoord = new MapCoordinate(rng);

            while (!(GetTile(randomCoord) is BlankTile))
            {
                randomCoord = new MapCoordinate(rng);
            }

            ChangeTile(randomCoord, new AppleTile());
        }
    }
}
