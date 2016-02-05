using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    class Garden
    {
        public int GARDEN_LENGTH = 6;
        public int GARDEN_WIDTH = 3;
        public int INITIAL_SUNS = 50;
        private int suns;
        private ArrayList sunflowers;

        public Garden()
        {
            suns = INITIAL_SUNS;
            sunflowers = new ArrayList();

        }

        public void addSuns(int suns)
        {
            this.suns += suns;
        }

        public void subtractSuns(int suns)
        {
            this.suns -= suns;
        }

        public void addSunflower(Sunflower sf)
        {
            sunflowers.Add(sf);
        }

        public void increment()
        {
            foreach (Sunflower sf in sunflowers)
            {
                sf.increment();
            }
        }

        public String toString()
        {
            String s = "";
            for(int a = 0; a < GARDEN_WIDTH; a++)
            {
                for (int b = 0; b < GARDEN_LENGTH; b++)
                {
                    if (hasSunflowerAt(b,a))
                    {
                        s += "S";
                    }
                    else
                    {
                        s += ".";
                    }
                }
                s += "\n";
            }
            s += "suns = " + suns + "\n";
            return s;
        }

        public void print()
        {
            Console.Write(this.toString());
        }

        private bool hasSunflowerAt(int x, int y)
        {
            foreach (Sunflower sf in sunflowers)
            {
                if (sf.getX() == x && sf.getY() == y)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Garden g = new Garden();
            Sunflower sf = new Sunflower(g, 1, 0);
            g.print();
            g.increment();
            g.increment();
            g.increment();
            g.print();

        }
    }
}
