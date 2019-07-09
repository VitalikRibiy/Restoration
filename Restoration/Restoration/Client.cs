using System;
using System.Collections.Generic;

namespace Restoration
{
    class Client : Person
    {

        //private readonly Client client = this;
        public Client(string f, string s, int a, double w) : base(f, s, a, w) { }
        protected Restaurant Restaurant { get; set; }

        public virtual Menu CheckMenu(Restaurant restaurant)
        {
            return restaurant.Menu;
        }

        public virtual List<Table> CheckTables(Restaurant restaurant)
        {
            List<Table> tables = new List<Table>();
            foreach (var i in restaurant.Tables)
            {
                if (i.IfForVipOnly == false && i.IsFree)
                {
                    tables.Add(i);
                }
            }
            return tables;
        }

        public virtual void VisitRestaurant(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Restaurant.Clients.Add(this);
            int[] tables = CheckTables(restaurant);
            int r = 0;
            if (tables.Length == 0)
            {
                throw new Exception("There are no free tables");
            }
            else
            {
                Console.WriteLine("Choose table:");
                foreach(int t in tables)
                {
                    Restaurant.Tables[t].Print();
                }
                r = Convert.ToInt32(Console.ReadLine());
                Restaurant.BookTable(r, this);
                Console.ReadKey();
                Console.Clear();
            }

            Restaurant = restaurant;
            foreach (var i in Restaurant.BlackList)
            {
                if (this == i.Key)
                {
                    Console.WriteLine($"{FullName} is in Black list of {Restaurant.RestName} restaurant,you need to pay {i.Value}$ ");
                }
            }
            Order(out var cost, r, CheckMenu(restaurant).Dishes[1], CheckMenu(restaurant).Dishes[2], CheckMenu(restaurant).Dishes[3], CheckMenu(restaurant).Dishes[1]);
            LeftTheRestaurant(cost, r);
        }

        public virtual void LeftTheRestaurant(double cost, int id)
        {
            Restaurant.CancelBooking(id, this);
            Restaurant.Tables[id].Order = null;
            if (Restaurant == null)
            {
                throw new Exception("Client is not in restaurant");
            }
            else
            {
                Pay(cost);
                Restaurant = null;
            }
        }

        public virtual void Pay(double cost)
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
        }

        public virtual void Order(out double cost, int id, params Dish[] dishes)
        {
            Order order = new Order(this, dishes);
            cost = order.Cheq;
            Restaurant.Tables[id].Order = order;
        }


        public virtual string Print()
        {
            return $"Name:{FullName}\tAge:{Age}\tWallet:{Wallet}";
        }
    }
}