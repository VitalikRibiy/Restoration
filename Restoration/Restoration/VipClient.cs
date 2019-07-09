using System.Collections.Generic;

namespace Restoration
{
    class VipClient : Client
    {
        public VipClient(string f, string s, int a, double w) : base(f, s, a, w) { }

        public override void LeftTheRestaurant(double cost, int id)
        {
            base.LeftTheRestaurant(cost, id);
        }

        public override void Order(out double cost, int id, params Dish[] dishes)
        {
            base.Order(out cost, id, dishes);
        }

        public override void Pay(double cost)
        {
            if (Wallet < cost)
            {
                Restaurant.Pay(Wallet - cost);
                double borg = cost - Wallet;
                Wallet = 0;
                Restaurant.BlackList.Add(this, borg);
            }
            else
            {
                Wallet -= cost;
                Restaurant.Pay(cost);
            }
            double tip = cost * 0.1;
            if (Wallet > tip)
            {
                Wallet -= tip;
                Restaurant.Pay(tip);
            }
            else
            {
                Wallet -= Wallet;
                Restaurant.Pay(tip);
            }
        }

        public override void VisitRestaurant(Restaurant restaurant)
        {
            base.VisitRestaurant(restaurant);
        }

        public override List<Table> CheckTables(Restaurant restaurant)
        {
            List<Table> tables = new List<Table>();
            foreach (var i in restaurant.Tables)
            {
                if (i.IsFree)
                {
                    tables.Add(i);
                }
            }
            return tables;
        } //переписати функцію 

        public override Menu CheckMenu(Restaurant restaurant)
        {
            return base.CheckMenu(restaurant);
        }

        public override string Print()
        {
            return base.Print()+"\tVIP";
        }
    }
}