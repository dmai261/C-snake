using C_nake.Interfaces;
using C_nake.Utilities;
using System;
using System.Diagnostics;
using C_nake.Constants;

namespace C_nake.Models
{
    public class Game : IDrawable
    {
        private Snake originalSnake;
        private Map map;
        private UserInput input;
        private int score;
        
        public Game()
        {
            map = new Map();
            originalSnake = new Snake(map);
            map.GenerateApple();
            input = new UserInput(new ConsoleMethods());
            score = 0;
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
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
            while (originalSnake.Move(ref score));
            GameOver();
            Console.CursorVisible = true;
        }
        
        /// <summary>
        /// Displays controls and draws the game map.
        /// </summary>
        public void Draw()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 1);

            Console.WriteLine("Use the arrow keys to control the snake and avoid colliding with the walls and your body!");
            Console.WriteLine($"Your score is: {score}");
            map.Draw();
        }


        /// <summary>
        /// Tells user when game is over, after snake collides with body or wall.
        /// </summary>
        public void GameOver()
        {
            Console.WriteLine("Game Over! The snake has collided!");
        }

    }
}
