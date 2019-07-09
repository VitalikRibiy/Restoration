using System;
using System.Linq;
using System.Collections.Generic;

namespace Restoration
{
    class Restaurant
    {
        public string RestName { get; private set; }
        public string Adress { get; private set; }
        public Menu Menu { get; private set; }
        public List<Table> Tables { get; private set; }
        public Dictionary<Client, double> BlackList { get; protected set; }
        protected List<Booking> BookingList { get; private set; }
        private double Money { get; set; }
        public List<Client> Clients { get; protected set; }

        public Restaurant(string name,string adress,Menu menu,List<Table> tables)
        {
            RestName = name;
            Adress = adress;
            Menu = menu;
            Tables = tables;
            Money = 0;
            Clients = new List<Client>();
            BlackList = new Dictionary<Client, double>();
            BookingList = new List<Booking>();
        }

        public void Pay(double sum)
        {
            Money += sum;
        }

        public double GetMoney()
        {
            return Money;
        }

        public void BookTable(int id, Client client)
        {
            foreach (Booking b in BookingList)
            {
                if (b.TableId == id)
                {
                    throw new Exception("This Table is already booked");
                }
            }
            {
                if ((Tables[id].IfForVipOnly == true) && !(client is VipClient))
                {
                    throw new Exception($"Table №{id} is only for VIP-Clients");
                }
                else
                {
                    BookingList.Add(new Booking(id, client));
                }
            }
        }

        public void CancelBooking(int id, Client client)
        {
            foreach (Booking b in BookingList)
            {
                if ((b.CLient == client) && (b.TableId == id))
                {
                    BookingList.Remove(b);
                }
            }
        }

        public int[] FreeTables(Client client)
        {
            List<int> tables = new List<int>();
            var quary = from i in Tables
                        where ((i.IsFree = true) && (i.IfForVipOnly = false))
                        select i.ID;
            foreach(var i in quary)
            {
                Console.WriteLine(i);
            }
            int[] index = quary.ToArray();
            return index;
        }

        public int[] FreeTables(VipClient client)
        {
            List<int> tables = new List<int>();
            var quary = from i in Tables
                        where i.IsFree = true
                        select i.ID;
            return quary.ToArray();
        }

        public bool isFreeTables()
        {
            foreach (Table table in Tables)
            {
                if (table.IsFree)
                {
                    return true;
                }
            }
            return false;
        }



        public void Print()
        {
            string tables = "";
            foreach(var i in Tables)
            {
                tables += i.Print();
            }
            string form = $"{RestName} ({Adress}):\n\nMenu:\n\t{Menu.Print()}\nTables:\n{tables}";
            Console.WriteLine(form+"\n");
        }



    }
}
