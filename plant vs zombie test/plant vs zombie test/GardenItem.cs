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
            //override in the subc
        }
    }
}
