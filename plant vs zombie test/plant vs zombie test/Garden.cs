using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace plant_vs_zombie_test
{
    class Garden
    {
        public int GARDEN_LENGTH = 6;
        public int GARDEN_WIDTH = 3;
        public int INITIAL_SUNS = 500;
        private int suns;
        private ArrayList sunflowers;
        private ArrayList peaShooters;
        private ArrayList peas;

        public Garden()
        {
            suns = INITIAL_SUNS;
            sunflowers = new ArrayList();
            peaShooters = new ArrayList();
            peas = new ArrayList();

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
            if (suns - Sunflower.COST >= 0 && !(hasSunflowerAt(sf.getX(), sf.getY())) && !(hasPeaShooterAt(sf.getX(), sf.getY())))
            {
                sunflowers.Add(sf);
                this.subtractSuns(Sunflower.COST);
            }
        }

        public void addPea(Pea p)
        {
            peas.Add(p);
        }

        public void addPeaShooter(PeaShooter ps)
        {
            if (suns - PeaShooter.COST >= 0 && !(hasSunflowerAt(ps.getX(),ps.getY())) && !(hasPeaShooterAt(ps.getX(), ps.getY())))
            {
                peaShooters.Add(ps);
                this.subtractSuns(PeaShooter.COST);
            }
        }

        public void increment()
        {
            foreach (Sunflower sf in sunflowers)
            {
                sf.increment();
            }

            foreach (Pea p in peas)
            {
                p.increment();
            }

            foreach (PeaShooter ps in peaShooters)
            {
                ps.increment();
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
                    else if (hasPeaShooterAt(b,a))
                    {
                        s += "P";
                    }else if (hasPeaAt(b, a))
                    {
                        s += "o";
                    }
                    else
                    {
                        s += ".";
                    }
                }
                s += "\n";
            }
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
            }
            return false;
        }

        private bool hasPeaShooterAt(int x, int y)
        {
            foreach (PeaShooter ps in peaShooters)
            {
                if (ps.getX() == x && ps.getY() == y)
                {
                    return true;
                }
            }
            return false;
        }

        private bool hasPeaAt(int x, int y)
        {
            foreach (Pea p in peas)
            {
                if (p.getX() == x && p.getY() == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void play()
        {
            for (;;)
            {
                this.print();
                Console.Write("You have: " + suns + " suns. Enter your next move: \n");
                Console.WriteLine("A Sunflower costs: " + Sunflower.COST + ", and a Pea Shooter costs: " + PeaShooter.COST);
                Console.WriteLine("\"s x y\" to add a sunflower, \"p x y\" to add a peashooter, \"q\" to quit, or just" +
                                   "hit enter to pass your turn");
                String[] input = Console.ReadLine().Split(' ');
                switch (input[0])
                {
                    case "q":
                        Console.WriteLine("Bye");
                        System.Threading.Thread.Sleep(1000);
                        return;
                    case "s":
                        this.addSunflower( new Sunflower(this, Int32.Parse(input[1]), Int32.Parse(input[2])));
                        break;
                    case "p":
                        this.addPeaShooter(new PeaShooter(this, Int32.Parse(input[1]), Int32.Parse(input[2])));
                        break;
                    default:
                            Console.WriteLine(peas.Count);
                        break;
                }
                this.increment();
            }
        }

        static void Main(string[] args)
        {
            Garden g = new Garden();
            g.play();
        }
    }
}
