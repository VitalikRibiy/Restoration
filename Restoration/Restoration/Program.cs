using System.IO;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Restoration
{
    class Program
    {
        static void Main()
        {
            //==============================TASK1================================//
            Dictionary<int,Restaurant> restaurants = GetRestaurants("Restaurants.txt");

            foreach(var i in restaurants.Values)
            {
                i.Print();
            }

            //==============================TASK2================================//

            int k = 0;
            List<Client> clients = new List<Client>();
            for (int i = 0; i < 3; i++)
            {
                VipClient client = new VipClient($"FirstName{i + 1}", $"SecondName{i + 1}",20* (i+1) - (i+1),200*(i+1));
                clients.Add(client);
                k = i;
            }
            for (int j=0;j<6;j++)
            {
                Client client = new Client($"FirstName{k+j+1 + 1}", $"SecondName{k+ j + 1 + 1}", 18 * (j + 1) - (j + 1), 100 * (j + 1));
                clients.Add(client);
            }

            foreach(Client i in clients)
            {   
                Console.WriteLine(i.Print());
            }
            //==============================TASK3================================//

            var rest = (from r in restaurants.Values
                                    select r).ToList();

            var tables = from t in rest
                         select t.Tables;
            
            var quary = (from i in tables
                        select i).Count();

            Console.WriteLine(quary);

            //==============================TASK4================================//

                Console.WriteLine("==================");
            foreach(var r in restaurants)
            {
                Console.WriteLine($"{r.Key}.{r.Value.RestName}");
            }


            foreach(Client c in clients)
            {
                foreach (var r in restaurants)
                {
                    Console.WriteLine($"{r.Key}.{r.Value.RestName}");
                }

                c.VisitRestaurant(restaurants[Convert.ToInt32(Console.ReadLine())]);
            }



            Console.ReadKey();

        }
        static Dictionary<int,Restaurant> GetRestaurants(string path)
        {
            Dictionary<int,Restaurant> restaurants = new Dictionary<int, Restaurant>();
            string[] restaurantData = File.ReadAllLines(path);
            int count = 1;
            foreach (string r in restaurantData)
            {
                string[] data = r.Split(';');
                List<Dish> dishes = new List<Dish>();
                foreach (var i in data[1].Split(','))
                {
                    string[] s = i.Split('/');
                    Dish dish = new Dish(s[0], Convert.ToDouble(s[1]), Convert.ToDouble(s[2].Replace('.',',')));
                    dishes.Add(dish);
                }
                List<Table> tables = new List<Table>();
                foreach (var i in data[2].Split(','))
                {
                    Table table = new Table(Convert.ToBoolean(i));
                    tables.Add(table);
                }
                Restaurant restaurant = new Restaurant(data[0].Split(',')[0], data[0].Split(',')[1], new Menu(dishes), tables);
                restaurants.Add(count,restaurant);
                count++;
            }
            return restaurants;
        }
    }
}

        


//4 не віпи 2 віпи