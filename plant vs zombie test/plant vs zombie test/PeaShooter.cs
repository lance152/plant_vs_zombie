namespace plant_vs_zombie_test
{
    public class PeaShooter
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
            garden.addPeaShooter(this);
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }


    }
}