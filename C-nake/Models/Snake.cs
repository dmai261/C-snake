using System;
using System.Collections.Generic;
using C_nake.Constants;
using C_nake.MapTiles;

namespace C_nake.Models
{
    public class Snake
    {
        private LinkedList<MapCoordinate> snake;
        private Map map;
        private Dictionary<ConsoleKey, ConsoleKey> arrowDictionary;
        private ConsoleKey _currentDirection;
        public ConsoleKey CurrentDirection
        {
            get => _currentDirection;
            set
            {
                if (isArrowKey(value) && isValidDirection(value))
                {
                    _currentDirection = value;
                }
            }
        }

        // 1 check if its arrow keys (4 options)
        private bool isArrowKey(ConsoleKey key)
        {

            return arrowDictionary.ContainsKey(key);
            
        }

        // 2 check if the arrow choice valid
        //currrent down -> up x down x not move 
        //current up -> down x up x no change
        // same for right and left 
        private bool isValidDirection(ConsoleKey direction)
        {
            ConsoleKey invalidDirection = arrowDictionary[CurrentDirection];
            return direction != invalidDirection;
        }

        /// <summary>
        /// Constructor for the game class.
        /// </summary>
        /// <param name="gameMap">Game map object to play on.</param>
        public Snake(Map gameMap)
        {
            map = gameMap;
            snake = new LinkedList<MapCoordinate>();
            arrowDictionary = new Dictionary<ConsoleKey, ConsoleKey>();
            arrowDictionary.Add(ConsoleKey.UpArrow, ConsoleKey.DownArrow);
            arrowDictionary.Add(ConsoleKey.DownArrow, ConsoleKey.UpArrow);
            arrowDictionary.Add(ConsoleKey.LeftArrow, ConsoleKey.RightArrow);
            arrowDictionary.Add(ConsoleKey.RightArrow, ConsoleKey.LeftArrow);

            var array = InitialSnake.InitialBody;
            addHead(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                addBody(array[i]);
            }

            _currentDirection = InitialSnake.InitialDirection;
        }

        // Add coordinate to linked list and matrix 
        private void addHead(MapCoordinate headCord)
        {
            snake.AddFirst(headCord);
            map.ChangeTile(headCord, new SnakeHeadTile());
        }

        // Add coordinate to linked list and matrix 
        private void addBody(MapCoordinate bodyCord)
        {
            snake.AddLast(bodyCord);
            map.ChangeTile(bodyCord, new SnakeBodyTile());
        }

        // Removes the tail after snake moves.
        private void removeTail()
        {
            MapCoordinate curTail = snake.Last.Value;
            map.ChangeTile(curTail, new BlankTile());
            snake.RemoveLast();
        }

        // Check if there will not be a collision.
        // Returns true if the next move is valid.
        private bool checkCollision(MapCoordinate newHead)
        {
            Tile nextTile = map.GetTile(newHead);
            return (nextTile is BlankTile || nextTile is AppleTile);
        }

        /// <summary>
        /// Move the snake one tile in the current direction.
        /// </summary>
        /// <returns>bool: If the snake was able to move</returns>
        public bool Move(ref int gameScore)
        {
            MapCoordinate newHead;
            MapCoordinate curHead = snake.First.Value;

            if (CurrentDirection == ConsoleKey.UpArrow)
            {
                newHead = new MapCoordinate(curHead.Row - 1, curHead.Col);
            }
            else if (CurrentDirection == ConsoleKey.DownArrow)
            {
                newHead = new MapCoordinate(curHead.Row + 1, curHead.Col);
            }
            else if (CurrentDirection == ConsoleKey.RightArrow)
            {
                newHead = new MapCoordinate(curHead.Row, curHead.Col + 1);
            }
            else            
            {
                newHead = new MapCoordinate(curHead.Row, curHead.Col - 1);
            }
            bool isNotCollided = checkCollision(newHead);
            if (isNotCollided)
            {
                bool willEatApple = map.GetTile(newHead) is AppleTile;
                map.ChangeTile(curHead, new SnakeBodyTile());
                addHead(newHead);

                if (willEatApple)
                {
                    map.GenerateApple();
                    gameScore += GameConstants.AppleScore;
                }
                else
                {
                    removeTail();
                }
            }
            return isNotCollided;
        }
    }
}
