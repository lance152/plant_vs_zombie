namespace plant_vs_zombie_test
{
    internal class PeaShooter
    {
        public static int COST = 100;
        public static int SHOT_PERIODICITY = 2;
        private Garden garden;
        private int positionInShotCycle;
        private int x, y;

        public PeaShooter(Garden g, int x, int y)
        {
            garden = g;
            this.x = x;
            this.y = y;
            positionInShotCycle = 0;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        private void shoot()
        {
            Pea p = new Pea(garden, x+1, y);
            garden.addPea(p);
        }

        public void increment()
        {
            positionInShotCycle = (positionInShotCycle + 1) % SHOT_PERIODICITY;
            if(positionInShotCycle == 0)
            {
                this.shoot();
            }
        }
    }
}