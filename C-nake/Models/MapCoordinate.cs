using System;
using C_nake.Constants;

namespace C_nake.Models
{
    public class MapCoordinate
    {
        public int Col { get; }
        public int Row { get; }

        /// <summary>
        /// Constructor for generating a random coordinate inside map bounds.
        /// </summary>
        /// <param name="rng">Reference to a Random instance</param>
        public MapCoordinate(Random rng)
        {
            Col = rng.Next(0, MapDimensions.Cols);
            Row = rng.Next(0, MapDimensions.Rows);
        }

        /// <summary>
        /// Constructor for specifying a map coordinate.
        /// </summary>
        /// <param name="row">Desired row.</param>
        /// <param name="col">Desired column</param>
        /// <exception cref="System.ArgumentException">Thrown if row or column out of bounds.</exception>
        public MapCoordinate(int row, int col)
        {
            bool rowOutOfBounds = row < 0 || row >= MapDimensions.Rows;
            bool colOutOfBounds = col < 0 || col >= MapDimensions.Cols;
            if (rowOutOfBounds || colOutOfBounds)
            {
                throw new ArgumentException("Coordinate is off the map.");
            }
            Col = col;
            Row = row;
        }
    }
}
