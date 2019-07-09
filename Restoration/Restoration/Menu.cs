using System.Collections;
using System.Collections.Generic;

namespace Restoration
{
    class Menu : IEnumerable
    {
        public List<Dish> Dishes = new List<Dish>();

        public Menu(List<Dish> dishes)
        {
            Dishes.AddRange(dishes);
        }

        public IEnumerator GetEnumerator()
        {
            return Dishes.GetEnumerator();
        }

        public string Print()
        {
            string s = "Dish\tWeight\tPricePer100";
            foreach(Dish i in Dishes)
                {
                s += $"\n\t{i.DishName}\t{i.Weight}\t{i.PricePer100Gr}";
                }
            return s;
        }
    }

}
