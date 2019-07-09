namespace Restoration
{
    class Person
    {
        public double Wallet { get; protected set; }
        private string FistName { get; set; }
        private string SecondName { get; set; }
        public string FullName
        {
            get
            {
                return $"{SecondName} {FistName}";
            }
        }
        public int Age { get; set; }

        public Person(string f, string s, int a, double w)
        {
            FistName = f;
            SecondName = s;
            Age = a;
            Wallet = w;
        }

    }
}
