using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class FoodCreator
    {
        int posX;
        int posY;
        public char foodImage = '♣';
        public FoodCreator(int x, int y)
        {
            posX = x;
            posY = y;

        }
    }
}
