namespace plant_vs_zombie_test
{
    internal abstract class GardenItem
    {
        protected Garden garden;
        protected int x, y,health;

        public GardenItem(Garden g,int x, int y)
        {
            garden = g;
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getHealth()
        {
            return health;
        }

        public void decreaseHealth(int h)
        {
            health -= h;
        }

        public abstract void increment();
     }
}
