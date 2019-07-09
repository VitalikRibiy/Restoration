using System.Collections.Generic;
using System.Linq;

namespace Restoration
{
    class Order
    {
        public double Cheq { get; set; }
        public List<Dish> Dishes { get; set; }

        public Order(Client client, params Dish[] dishes)
        {
            Cheq = (from i in dishes
                    select (i.PricePer100Gr * i.Weight / 100.0)).Sum();
            foreach(Dish d in dishes)
            { 
                Dishes.Add(d);
            }
        }

        public Order(VipClient client, params Dish[] dishes)
        {
            Cheq = (from i in dishes
                    select (i.PricePer100Gr * i.Weight / 100.0)).Sum();

            Cheq *= 0.8;
        }
     
        
        public string Print()
        {
            string s="";
            foreach(Dish d in Dishes)
            {
                s += $"\tDish:{d.DishName}\n\tWeight{d.Weight}\n";
            }
            s += $"Cheq:{Cheq}";

            return s;
        }
    }
}
