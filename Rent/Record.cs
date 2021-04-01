using System.Configuration;

namespace Rent
{
    class Record
    {
        public static int CurrentID { get; private set; }
        public int ID { get; private set; }
        public PremisesType TypeOfPremises { get; private set; }
        public string Address { get; private set; }
        public int Square { get; private set; }
        public int NumberOfRooms { get; private set; }
        public double Price { get; private set; }
        private User LandLord { get; set; }
        public string LandLordName { get; private set; }
        public string LandLordPhoneNumber { get; private set; }

        public Record(PremisesType typeOfPremises, string address, int square, int numberOfRooms, double price, User landLord)
        {
            ID = CurrentID;
            CurrentID++;
            ConfigurationManager.AppSettings.Set("ID", $"{CurrentID}");

            TypeOfPremises = typeOfPremises;
            Address = address;
            Square = square;
            NumberOfRooms = numberOfRooms;
            Price = price;
            LandLord = landLord;
            LandLordName = LandLord.Name;
            LandLordPhoneNumber = LandLord.PhoneNumber;
        }
    }
}