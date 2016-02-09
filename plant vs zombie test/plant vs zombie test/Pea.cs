using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class Pea : GardenItem
    {

        public Pea(Garden g, int x, int y):base(g,x,y)
        {
        }

        public new void increment()
        {
            x++;
        }
    }
}
