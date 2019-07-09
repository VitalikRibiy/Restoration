namespace Restoration
{
    class Dish
    {
        public string DishName { get; set; }
        public double Weight { get; set; }
        public double PricePer100Gr { get; set; }

        public Dish(string name, double w, double price)
        {
            DishName = name;
            Weight = w;
            PricePer100Gr = price;
        }
    }
}
