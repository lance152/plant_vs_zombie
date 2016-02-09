namespace plant_vs_zombie_test
{
    internal class PeaShooter:Plant
    {
        public static new int COST = 100;
        public static int SHOT_PERIODICITY = 2;
        private int positionInShotCycle;
        private int INITIAL_HEALTH = 2000;

        public PeaShooter(Garden g, int x, int y):base(g,x,y)
        {
            positionInShotCycle = 0;
            health = INITIAL_HEALTH;
        }

        private void shoot()
        {
            garden.addPea(new Pea(garden, getX()+1, getY()));
        }

        public override void increment()
        {
            positionInShotCycle = (positionInShotCycle + 1) % SHOT_PERIODICITY;
            if (positionInShotCycle == 0)
            {
                this.shoot();
            }
        }

        public override int getCost()
        {
            return COST;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}