using C_nake.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_nake.Utilities
{
    public class UserInput : IUserInput
    {

        private UserInput(IConsoleWrapper consoleMethods)
        {
            console = consoleMethods;
        }

        IConsoleWrapper console;

        public ConsoleKey GetMove()
        {
            ConsoleKeyInfo input;

            input = console.ReadKey();

            ConsoleKey keyPressed = input.Key;

            return keyPressed;
        }
    }
}
