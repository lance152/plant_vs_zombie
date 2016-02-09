using System;
using System.Collections;

namespace plant_vs_zombie_test
{
    class Garden
    {
        public int GARDEN_LENGTH = 6;
        public int GARDEN_WIDTH = 3;
        public int INITIAL_SUNS = 500;
        public int ZOMBIE_CREATION_PERIODICITY = 3;
        public int MAX_ZOMBIE = 50000;
        private int suns,totalzombie;
        private ArrayList plants;
        private ArrayList peas;
        private ArrayList zombies;

        public Garden()
        {
            suns = INITIAL_SUNS;
            plants = new ArrayList();
            peas = new ArrayList();
            zombies = new ArrayList();
            totalzombie = 0;

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

        public void addZombie(Zombie z)
        {
            zombies.Add(z);
        }

        private void generateZombie()
        {
            Random num = new Random();
            int a = num.Next(ZOMBIE_CREATION_PERIODICITY);
            if (a == 0 && totalzombie <= MAX_ZOMBIE)
            {
                addZombie(new Zombie(this, GARDEN_LENGTH, num.Next(GARDEN_WIDTH)));
                totalzombie++;
            }
        }

        private void removeDeadItems()
        {
            ArrayList pealive = new ArrayList();
            foreach (Pea p in peas)
            {
                if (p.getHealth() > 0)
                {
                    pealive.Add(p);
                }
            }
            peas = pealive;

            ArrayList plalive = new ArrayList();
            foreach (Plant pl in plants)
            {
                if (pl.getHealth() > 0)
                {
                    plalive.Add(pl);
                }
            }
            plants = plalive;

            ArrayList zalive = new ArrayList();
            foreach (Zombie z in zombies)
            {
                if (z.getHealth() > 0)
                {
                    zalive.Add(z);
                }
            }
            zombies = zalive;
        }

        public void increment()
        {
            generateZombie();

            foreach (Pea p in peas)
            {               
                p.increment();
            }

            foreach (Plant pl in plants)
            {
                pl.increment();
            }

            foreach (Zombie z in zombies)
            {
                z.increment();
            }
            removeDeadItems();
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

        public Zombie getZombieAt(int x, int y)
        {
            foreach (Zombie z in zombies)
            {
                if (z.getX() == x && z.getY() == y)
                {
                    return z;
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
                    Plant pl = getPlantAt(b, a);
                    if (pl != null)
                    {
                        s += pl;
                    }else if (hasZombieAt(b, a))
                    {
                        s += "Z";
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

        internal bool hasPlantAt(int x, int y)
        {
            return getPlantAt(x, y) != null;
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

        private bool hasZombieAt(int x,int y)
        {
            return getZombieAt(x, y) != null;
        }

        private bool Win()
        {
            return totalzombie == MAX_ZOMBIE;
        }

        private bool Lost()
        {
            foreach (Zombie z in zombies)
            {
                if (z.getX() < 0)
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
                if (Win())
                {
                    Console.WriteLine("You survived the zombies!");
                    System.Threading.Thread.Sleep(1000);
                    return;
                }
                if (Lost())
                {
                    Console.WriteLine("The zombies ate your brain!");
                    System.Threading.Thread.Sleep(1000);
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            Garden g = new Garden();
            g.play();
        }
    }
}
