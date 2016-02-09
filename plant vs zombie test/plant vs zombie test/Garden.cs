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
        private ArrayList plants;
        private ArrayList peas;

        public Garden()
        {
            suns = INITIAL_SUNS;
            plants = new ArrayList();
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

        public void addPlant(Plant pl)
        {
            if (suns - pl.getCost() >= 0 && !(hasPlantAt(pl.getX(), pl.getY())))
            {
                plants.Add(pl);
                this.subtractSuns(pl.getCost());
            }
        }

        public void addPea(Pea p)
        {
            peas.Add(p);
        }

        public void increment()
        {

            foreach (Pea p in peas)
            {
                p.increment();
            }

            foreach (Plant pl in plants)
            {
                pl.increment();
            }
        }

        public Plant getPlantAt(int x, int y)
        {
            foreach(Plant pl in plants)
            {
                if(pl.getX() == x && pl.getY() == y)
                {
                    return pl;
                }
            }
            return null;
        }

        public String toString()
        {
            String s = "";
            for(int a = 0; a < GARDEN_WIDTH; a++)
            {
                for (int b = 0; b < GARDEN_LENGTH; b++)
                {
                    if (hasPlantAt(b,a))
                    {
                        Plant pl = getPlantAt(b, a);
                        s += pl.ToString();
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

        private bool hasPlantAt(int x, int y)
        {
            foreach (Plant pl in plants)
            {
                if (pl.getX() == x && pl.getY() == y)
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
                        this.addPlant( new Sunflower(this, Int32.Parse(input[1]), Int32.Parse(input[2])));
                        break;
                    case "p":
                        this.addPlant(new PeaShooter(this, Int32.Parse(input[1]), Int32.Parse(input[2])));
                        break;
                    default:
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
