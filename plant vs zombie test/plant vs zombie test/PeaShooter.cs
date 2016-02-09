namespace plant_vs_zombie_test
{
    internal class PeaShooter:Plant
    {
        public static new int COST = 100;
        public static int SHOT_PERIODICITY = 2;
        private int positionInShotCycle;

        public PeaShooter(Garden g, int x, int y):base(g,x,y)
        {
            positionInShotCycle = 0;
        }

        private void shoot()
        {
            Pea p = new Pea(garden, x+1, y);
            garden.addPea(p);
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