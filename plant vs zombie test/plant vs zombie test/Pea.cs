namespace plant_vs_zombie_test
{
    internal class Pea : GardenItem
    {
        private int INITIAL_HEALTH = 1;
        private int DAMAGE = 10;

        public Pea(Garden g, int x, int y):base(g,x,y)
        {
            health = INITIAL_HEALTH;
        }

        public override void increment()
        {
            Zombie z = garden.getZombieAt(x, y);
            if(z != null)
            {
                z.decreaseHealth(DAMAGE);
                decreaseHealth(DAMAGE);
            }
            if (x > garden.GARDEN_LENGTH)
            {
                decreaseHealth(DAMAGE);
            }
            x++;

        }

        public int getDamage()
        {
            return DAMAGE;
        }
        public override string ToString()
        {
            return "o";
        }
    }
}
