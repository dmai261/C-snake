using System;
using C_nake.Interfaces;

namespace C_nake.MapTiles
{
    public abstract class Tile : IDrawable
    {
        protected ConsoleColor color;
        public ConsoleColor Color { get { return color; } }
        protected char symbol;
        public char Symbol { get { return symbol; } }

        public void Draw()
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
            Console.ForegroundColor = originalColor;
        }
    }
}
