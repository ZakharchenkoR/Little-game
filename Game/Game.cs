using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Game_g
    {
        int size;
        int[,] map;
        int spase_x;
        int spase_y;
        public static Random rand = new Random();
        public Game_g(int size)
        {
            if (size < 2)
                size = 2;
            if (size > 5)
                size = 5;
            this.size = size;
            map = new int[size, size];
        } 

        public void start()
        {
            for (int i = 0; i < size; i++)
            {
                for (int y = 0; y < size; y++)
                {
                    map[i, y] = coor_to_position(i, y) + 1;
                }
            }
            spase_x = size - 1;
            spase_y = size - 1;
            map[spase_x,spase_y] = 0;
            
        }

        public int get_numder(int position)
        {
            int x;
            int y;
            position_to_coor(position, out x, out y);
            if (x < 0 || x > size)
                return 0;
            if (y < 0 || y > size)
                return 0;
            return map[x, y];
        }


        public void shift_random()
        {
            int a = rand.Next(0, 4);
            int x = spase_x;
            int y = spase_y;
            switch(a)
            {
                case 0:x--;break;
                case 1:x++;break;
                case 2: y--;break;
                case 3: y++;break;
            }
            shift(coor_to_position(x, y));
        }


        public void shift(int position)
        {
            int x;
            int y;
            position_to_coor(position, out x, out y);
            if (Math.Abs(spase_x - x) + Math.Abs(spase_y - y) != 1)
                return;
            map[spase_x, spase_y] = map[x, y];
            map[x, y] = 0;
            spase_x = x;
            spase_y = y;
        }

        private int coor_to_position(int x,int y)
        {
            if (x < 0)
                x = 0;
            if (x > size - 1)
                x = size - 1;
            if (y < 0)
                y = 0;
            if (y > size - 1)
                y = size - 1;     
            return y * size + x;
        }

        private void position_to_coor(int position, out int x,out int y)
        {
            if (position < 0)
                position = 0;
            if (position > size * size - 1)
                position = size * size - 1;
            x = position % size;
            y = position / size;
        }

        public bool chec_numbers()
        {
            if (!(spase_x == size - 1 &&
                spase_y == size - 1))
                return false;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!(i == size - 1 && spase_y == size - 1))
                       if(map[i,j] != coor_to_position(i,j)+1)
                         return false;
                }
            }
            return true;
                  
        }



    }
}
