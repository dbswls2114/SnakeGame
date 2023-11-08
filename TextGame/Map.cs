using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Map
    {
        public enum TileType 
        {
            grass,
            wall,
            snake,
            food
            //enum을 한번 써보기로 했다 맵을 그리기 위해 벽,땅,뱀,음식 타일을 정해주었다.
        }
        public Snake snake;
        public FoodCreator food;

        public TileType[,] tile; //2차원 배열을 선언했음
        public int mapSize; //2차원 배열에 x*x 사이즈를 위한 int값
        static char tileimage = '■';  // 땅타일이 2칸을 잡아먹어서 뱀의X값을 움직일 때에는 *2를 해주어야한다         '\u25cf'유니코드

        int score = 0; //임시로 점수 표기

        public Map(Snake _snake, FoodCreator _food)
        {
            snake = _snake;
            food = _food;
        }

        public void MapRender(int Size) //맵 타일그리기
        {
            tile = new TileType[Size*2, Size];
            mapSize = Size;
            ConsoleColor prevColor = Console.ForegroundColor; //기존 색상을 저장

            for (int x = 0; x < mapSize; x++)
            {
                for (int y = 0; y < mapSize; y++)
                {
                    if (x == 0 || x == mapSize - 1 || y == 0 || y == mapSize - 1)   // 가장 자리의 타일들을 벽으로 정의
                    {
                        tile[x, y] = TileType.wall;
                    }else if(tile[x ,y] != TileType.snake || tile[x, y] != TileType.food) // 가장 자리가 아닌 타일들은 갈 수 있는 곳으로 정의
                    {
                        tile[x, y] = TileType.grass;
                    }                       
                    Console.ForegroundColor = GetTileColor(tile[x, y]); //타일색상지정
                    Console.Write(tileimage);  // 타일 그리기
                }
                Console.WriteLine();  //한칸 밑으로 내리기
            }
            Console.ForegroundColor = prevColor; //맵그리기가 끝나면 다시 기존색상으로 변경
        }     

        public void SnakeRender()
        {
            for(int i = 0; i < snake.bodypos.Count; i++)
            {
                Draw(snake.bodypos[i], TileType.snake, snake.bodyImage);              
            }
            snake.Move();
            snake.bodypos.Insert(1, snake.headpos); //뭐가문제지
            snake.bodypos.RemoveAt(snake.bodypos.Count - 1);
        }

        public void scoreRender()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0,mapSize+1); //스코어를 그릴 위치로 커서이동
            Console.Write($"ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ\n" +
                          $"|     점수 : {score}          |     길이 : {snake.bodypos.Count}           |\n" +
                          $"ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ\n");

        }
        void Draw(Point _pos, TileType _tileType, char _image)
        {
            tile[_pos.x, _pos.y] = _tileType;
            Console.ForegroundColor = GetTileColor(tile[_pos.x,_pos.y]); //타일색상지정
            Console.SetCursorPosition(_pos.x,_pos.y); // 받아온 머리부분으로 커서이동
            Console.Write(_image); //이미지 그리기                 
        }
        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.grass:  // 갈 수 있는 곳이면 초록색 리턴
                    tileimage = '■';
                    return ConsoleColor.Green;
                case TileType.wall:  // 갈 수 없는 벽이면 빨간색 리턴
                    tileimage = '■';
                    return ConsoleColor.Red;
                case TileType.snake: // 뱀은 파란색
                    tileimage = snake.bodyImage; //뱀의 이미지
                    return ConsoleColor.Blue;
                case TileType.food: // 음식은 노란색
                    tileimage = food.foodImage; //음식의 이미지
                    return ConsoleColor.Yellow;
                default:  // 디폴트는 초록색 리턴
                    return ConsoleColor.Green;
            }
        }
    }
}
