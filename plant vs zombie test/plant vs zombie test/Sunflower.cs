namespace plant_vs_zombie_test
{
    internal class Sunflower
    {
        public int COST = 50;
        public int YIELD = 20;
        public int PRODUCTION_CYCLE = 3;
        private Garden garden;
        private int positionInCYcle;
        private int x, y;

        public Sunflower(Garden g, int x, int y)
        {
            garden = g;
            this.x = x;
            this.y = y;
            positionInCYcle = 0;
            g.addSunflower(this);
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void increment()
        {
            positionInCYcle++;
            if(positionInCYcle % 3 == 0)
            {
                this.produceSuns();
                positionInCYcle = 0;
            }
        }

        private void produceSuns()
        {
            garden.addSuns(YIELD);
        }
    }
}