using C_nake.Interfaces;
using System;

namespace C_nake.Utilities
{
    public class UserInput : IUserInput
    {
        private IConsoleWrapper console;

        /// <summary>
        /// Constructor for UserInput.
        /// </summary>
        /// <param name="consoleMethods">Implementation of a console wrapper to use for input.</param>
        public UserInput(IConsoleWrapper consoleMethods)
        {
            console = consoleMethods;
        }

        /// <summary>
        /// Obtains one key from the current console wrapper.
        /// </summary>
        /// <returns>ConsoleKey: The key pressed.</returns>
        public ConsoleKey GetMove()
        {
            ConsoleKeyInfo input;

            input = console.ReadKey();

            ConsoleKey keyPressed = input.Key;

            return keyPressed;
        }
    }
}
