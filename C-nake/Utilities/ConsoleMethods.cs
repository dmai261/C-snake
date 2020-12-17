using C_nake.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace C_nake.Utilities
{
    public class ConsoleMethods : IConsoleWrapper
    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(true);
        }
    }
}
