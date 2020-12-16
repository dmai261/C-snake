using C_nake.Constants;

namespace C_nake.MapTiles
{
    public class BlankTile : Tile
    {
        public BlankTile()
        {
            color = MapTileColors.Blank;
            symbol = MapTileSymbols.Blank;
        }
    }
}
