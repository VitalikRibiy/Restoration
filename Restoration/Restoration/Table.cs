using System;
using System.Collections.Generic;

namespace Restoration
{
    class Table
    {
        static List<int> Numbers=new List<int>();
        public int _id;
        public bool IsFree { get; set; }
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                foreach (int i in Numbers)
                {
                    if (i == value)
                    {
                        throw new Exception("There are table with the same number");
                    }
                }
                _id = value;
                Numbers.Add(value);

            }

        }
        public Order Order { get; set; }
        public Client ClientName { get; set; }
        public bool IfForVipOnly { get; set; }

        public Table(bool vip)
        {
            if(Numbers.Count==0)
            {
                ID = 1;
                Numbers.Add(ID);
            }
            else
            {
                ID = Numbers[Numbers.Count - 1] + 1;
                Numbers.Add(ID);
            }
            IfForVipOnly = vip;
            IsFree = true;
        }

        public string Print()
        {
            string s = $"\tTableId={ID}\n\t\tStatus(Free):{IsFree}\n\t\tForVips:{IfForVipOnly}\n\t\tOrder:{(Order==null ? "No Order\n" : Order.Print())}";//Тернарний оператор для перевірки ОРДЕРУ !
            return s;
        }
    }
}
