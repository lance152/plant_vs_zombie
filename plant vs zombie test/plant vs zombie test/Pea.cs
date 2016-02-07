using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class Pea
    {
        private Garden garden;
        private int x, y;
        public Pea(Garden g, int x, int y)
        {
            garden = g;
            this.x = x;
            this.y = y;
            garden.addPea(this);
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public void increment()
        {
            x++;
        }
    }
}
