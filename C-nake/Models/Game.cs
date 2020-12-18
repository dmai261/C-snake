using C_nake.Interfaces;
using C_nake.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using C_nake.Constants;

namespace C_nake.Models
{
    public class Game
    {
        private Snake originalSnake;
        private Map map;
        private UserInput input;
        
        public Game()
        {
            map = new Map();
            originalSnake = new Snake(map);
            map.GenerateApple();
            input = new UserInput(new ConsoleMethods());
        }

        public void Start()
        {
            Stopwatch clock = new Stopwatch();
            do
            {
                Draw();
                clock.Start();
                while (clock.Elapsed.TotalMilliseconds < GameConstants.RefreshRate)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey nextMove = input.GetMove();
                        originalSnake.CurrentDirection = nextMove;
                        break;
                    }
                }
                clock.Reset();
            } 
            while (originalSnake.Move());
            GameOver();
            Console.CursorVisible = true;
        }
        
        public void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 1);

            Console.WriteLine("Use the arrow keys to control the snake and avoid colliding with the walls and your body!");
            map.Draw();
        }


        //when snake collides with body or wall:
        public void GameOver()
        {
            Console.WriteLine("Game Over! The snake has collided!");
        }

    }
}
