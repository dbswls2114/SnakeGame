using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class FoodCreator
    {
        public Point foodPos;
        int mapSize;
        public char foodImage = '♣';
        public bool isfood = false;
        Random rand = new Random();

        public FoodCreator(int _mapSize)
        {
            mapSize = _mapSize;
            foodPos = new Point(0, 0);
        }

        public void spawnfood()
        {
            int _foodPosX = rand.Next(1, mapSize-1);
            int _foodPosY = rand.Next(1, mapSize-1);

            foodPos.x =_foodPosX*2;
            foodPos.y =_foodPosY;

            isfood = true;
        }

        public void EatFood(Map _map)
        {         
            _map.tile[foodPos.x, foodPos.y] = Map.TileType.grass;
            isfood = false;
        }

    }
}
