using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class GardenItem
    {
        protected Garden garden;
        protected int x, y;

        public GardenItem(Garden g,int x, int y)
        {
            garden = g;
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void increment()
        {
            return;//override in the subc
        }
    }
}
