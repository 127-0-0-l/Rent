namespace Rent
{
    class Record
    {
        public PremisesType TypeOfPremises { get; private set; }
        public string Address { get; private set; }
        public int Square { get; private set; }
        public int NumberOfRooms { get; private set; }
        public double Price { get; private set; }
        public User LandLord { get; private set; }

        public Record(PremisesType typeOfPremises, string address, int square, int numberOfRooms, double price, User landLord)
        {
            TypeOfPremises = typeOfPremises;
            Address = address;
            Square = square;
            NumberOfRooms = numberOfRooms;
            Price = price;
            LandLord = landLord;
        }
    }
}