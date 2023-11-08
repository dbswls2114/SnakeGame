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
        public static int gameSpeed = 500;

        static void Main(string[] args)
        {
            
            //뱀의 초기 위치, 길이, 방향을 설정하고, 그립니다.
            Point startPos = new Point(2, 1);
            Snake snake = new Snake(startPos, Direction.RIGHT);//땅을 그리는 타일이 2칸을 잡아먹어서 뱀,음식의 X값은 *2를 해주어야 한다
            //음식의 위치를 무작위로 생성하고, 그립니다.
            FoodCreator food = new FoodCreator(80, 20);
            //Point food = foodCreator.CreateFood();
            //food.Draw();

            Map map = new Map(snake,food);

            
            // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
            while (true)
            {
                Console.Clear();
                map.MapRender(25);
                map.SnakeRender();
                map.scoreRender();
                Thread.Sleep(gameSpeed); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)
                Thread.Sleep(1000);
                // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)
            }
        }
    }

    //예제코드 예제코드는 쓰지말고 만들어보자
    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
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
    // 방향을 표현하는 열거형입니다.
    

}