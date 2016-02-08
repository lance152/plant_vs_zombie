using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class Pea : GardenItem
    {

        public Pea(Garden g, int x, int y)
        {
            garden = g;
            this.x = x;
            this.y = y;
        }

        public void increment()
        {
            x++;
        }
    }
}
