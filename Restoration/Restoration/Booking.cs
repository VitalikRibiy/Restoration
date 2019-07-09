namespace Restoration
{
    class Booking
    {
        public int TableId { get; set; }
        public Client CLient { get; set; }

        public Booking(int i, Client client)
        {
            TableId = i;
            CLient = client;
        }
    }
}
