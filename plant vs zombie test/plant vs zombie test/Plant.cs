namespace plant_vs_zombie_test
{
    internal abstract class Plant:GardenItem
    { 
        public Plant(Garden g, int x, int y):base(g,x,y)
        {

        }

        public abstract int getCost();

        public override abstract void increment();

    }
}
