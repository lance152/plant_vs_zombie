using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class Plant
    {
        public static int COST;
        protected Garden g;
        protected int x, y;

        public Plant (Garden g, int x, int y)
        {
            this.g = g;
            this.x = x;
            this.y = y;
        }

        public int getCost()
        {
            return 0; //override in the subclass
        }

        public void increment()
        {
            //override in the subclass
        }
    }
}
