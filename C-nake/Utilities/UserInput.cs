using C_nake.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_nake.Utilities
{
    public class UserInput : IUserInput
    {
        public string GetMove()
        {
            ConsoleKeyInfo input;

            input = Console.ReadKey(true);

            string keyPressed = input.Key.ToString();

            return keyPressed;
        }
    }
}
