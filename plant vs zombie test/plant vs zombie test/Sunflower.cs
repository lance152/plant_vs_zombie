namespace plant_vs_zombie_test
{
    class Sunflower:Plant
    {
        public static new int COST = 50;
        public static int YIELD = 20;
        public int PRODUCTION_CYCLE = 3;
        private int positionInCYcle;
        private int INITIAL_HEALTH = 10;

        public Sunflower(Garden g, int x, int y):base(g,x,y)
        {
            health = INITIAL_HEALTH;
            positionInCYcle = 0;
        }

        public override void increment()
        {
            positionInCYcle++;
            if (positionInCYcle % 3 == 0)
            {
                this.produceSuns();
                positionInCYcle = 0;
            }
        }

        public void produceSuns()
        {
            garden.addSuns(YIELD);
        }

        public override int getCost()
        {
            return COST;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}