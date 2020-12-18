using C_nake.Models;
using System;

namespace C_nake.Constants
{
    public class InitialSnake
    {

        public const ConsoleKey InitialDirection = ConsoleKey.DownArrow;

        const int initialRow = MapDimensions.Rows / 2 - 1;
        const int initialCol = MapDimensions.Cols / 2 - 1;
        public static MapCoordinate[] InitialBody = new MapCoordinate[] {
            new MapCoordinate(initialRow, initialCol),
            new MapCoordinate(initialRow-1, initialCol),
            new MapCoordinate(initialRow-2, initialCol)
        };
    }
}
