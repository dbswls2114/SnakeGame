namespace TextGame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Threading;

    class Program
    {
        public static int gameSpeed = 100;
        public static int mapSize = 25;

        static void Main(string[] args)
        {

            //뱀의 초기 위치, 길이, 방향을 설정하고, 그립니다.
            Point startPos = new Point(2, 1);
            Snake snake = new Snake(startPos, Direction.RIGHT);//땅을 그리는 타일이 2칸을 잡아먹어서 뱀,음식의 X값은 *2를 해주어야 한다
            //음식의 위치를 무작위로 생성하고, 그립니다.
            FoodCreator food = new FoodCreator(mapSize);
            //Point food = foodCreator.CreateFood();
            //food.Draw();
            Map map = new Map(snake, food, mapSize);
            map.StartMapRender();
            // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
            while (!Win(snake))
            {
                Inputkey(snake);
                map.FoodRender();
                map.SnakeRender();            
                FoodEatCheck(snake, food, map);
                map.MapRender();           
                map.scoreRender();
                //map.DoubleBuffer();
                Thread.Sleep(gameSpeed); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)
                // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)
                if (Lose(snake, map))
                {
                    Console.WriteLine("패배하셨습니다~!");
                    break;
                }
            }
            if (Win(snake))
            {
                Console.WriteLine("승리하셨습니다~!");
            }
        }
        public static void Inputkey(Snake s)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        s.direction = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        s.direction = Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        s.direction = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        s.direction = Direction.DOWN;
                        break;
                }
            }            
        }

        public static void FoodEatCheck(Snake _snake, FoodCreator _food, Map _map)
        {
            if (_snake.bodypos[0].x == _food.foodPos.x && _snake.bodypos[0].y == _food.foodPos.y)
            {
                _map.score++;
                _snake.EatFood(_snake);
                _food.EatFood(_map);
                //뱀의 길이가 늘어나는함수
                //음식이 지워지고 새로운곳에 생성되는 함수
            }
        }

        public static bool Win(Snake _snake)
        {
            return _snake.bodypos.Count >= (mapSize - 2) * (mapSize - 2);    
        }
        public static bool Lose(Snake _snake, Map _map)
        {
            if (_snake.bodypos[0].x < 1 || _snake.bodypos[0].x > mapSize*2-1 || _snake.bodypos[0].y < 1 || _snake.bodypos[0].y > mapSize - 1)
            {
                return true;
            }
            for(int i = 1; i < _snake.bodypos.Count; i++)
            {
                if(_snake.bodypos[0].x == _snake.bodypos[i].x && _snake.bodypos[0].y == _snake.bodypos[i].y)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
    
    // 방향을 표현하는 열거형입니다.
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    //예제코드 예제코드는 쓰지말고 만들어보자
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public char sym { get; set; }

        // Point 클래스 생성자
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ위에는 사용중 ㅋㅋ
        // 점을 그리는 메서드
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        // 점을 지우는 메서드
        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        // 두 점이 같은지 비교하는 메서드
        public bool IsHit(Point p)
        {
            return p.x == x && p.y == y;
        }
    }
    
    

}