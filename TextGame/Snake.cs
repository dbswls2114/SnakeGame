using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static TextGame.Map;
using System.Xml.Linq;

namespace TextGame
{

    internal class Snake
    {
        public int headX;
        public int headY;
        public List<Point> bodypos = new List<Point>();
        public Direction direction;
        public char bodyImage = '◈';
        public Point headpos;

        public Snake(Point pos, Direction _direction)
        {
            direction = _direction;           
            for (int i = 0; i < 5; i++)
            {
                Point p = new Point(pos.x, pos.y+i);
                bodypos.Add(p);
            } 
        }

        public void Move()
        {          
            headX = bodypos[0].x; //이전 머리의 위치
            headY = bodypos[0].y;
            headpos = new Point(headX, headY);

            switch (direction)
            {
                case Direction.UP:
                    bodypos[0].y--;                    
                    break;
                case Direction.DOWN:
                    bodypos[0].y++;
                    break;
                case Direction.LEFT:
                    bodypos[0].x -= 2;
                    break;
                case Direction.RIGHT:
                    bodypos[0].x += 2;
                    break;
            }
            /* 머리의 위치값을 체크해보았다
            Console.SetCursorPosition(0, 26);
            Console.WriteLine($"X : {bodypos[0].x} Y : {bodypos[0].y}"); 
            */
        }
        
        public void EatFood(Snake _snake)
        {
            //뱀의 길이를 늘려주기
            _snake.bodypos.Add(_snake.bodypos[_snake.bodypos.Count-1]);
        }


    }
}

