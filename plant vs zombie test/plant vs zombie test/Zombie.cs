using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    internal class Zombie:GardenItem
    {
        private int INITIAL_HEALTH = 9;
        private int DAMAGE = 10;

        public Zombie(Garden g, int x, int y) : base(g, x, y)
        {
            health = INITIAL_HEALTH;
        }

        public override void increment()
        {

            Plant pl = garden.getPlantAt(x - 1, y);
            Pea p = garden.getPeaAt(x, y);

            if(pl != null)
            {
                pl.decreaseHealth(DAMAGE);
            }else if(p != null)
            {
                p.decreaseHealth(DAMAGE);
                decreaseHealth(p.getDamage());
            }
            else
            {
                x--;
            }
        }

        public override string ToString()
        {
            return "Z";
        }
    }
}
