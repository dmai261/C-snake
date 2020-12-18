using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
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

        //add coordinate to linked list and matrix 
        private void addHead(MapCoordinate headCord)
        {
            snake.AddFirst(headCord);
            map.ChangeTile(headCord, new SnakeHeadTile());
        }

        //add coordinate to linked list and matrix 
        private void addBody(MapCoordinate bodyCord)
        {
            snake.AddLast(bodyCord);
            map.ChangeTile(bodyCord, new SnakeBodyTile());
        }


        private void removeTail()
        {
            MapCoordinate curTail = snake.Last.Value;
            map.ChangeTile(curTail, new BlankTile());
            snake.RemoveLast();
        }

        private bool checkCollision(MapCoordinate newHead)
        {
            return (map.GetTile(newHead) is BlankTile);
        }

        public bool Move()
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
                map.ChangeTile(curHead, new SnakeBodyTile());
                addHead(newHead);
                removeTail();
            }
            return isNotCollided;
        }
    }
}
