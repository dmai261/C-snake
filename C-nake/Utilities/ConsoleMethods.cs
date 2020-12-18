using C_nake.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace C_nake.Utilities
{
    public class ConsoleMethods : IConsoleWrapper
    {
        /// <summary>
        /// Reads a key from the console.
        /// </summary>
        /// <returns>ConsoleKeyInfo: The info of key pressed in console.</returns>
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);
        }
    }
}
