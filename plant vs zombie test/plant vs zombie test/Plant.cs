using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class Plant:GardenItem
    {
        public static int COST = 0;

        public Plant(Garden g, int x, int y):base(g,x,y)
        {

        }

        public virtual int getCost()
        {
        return COST; //override in the subclass
        }

        public new virtual void increment()
        {
            return;//override in the subclass
        }

    }
}
