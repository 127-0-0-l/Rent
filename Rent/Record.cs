using System.Configuration;
using System.IO;

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
        public string LandLordName { get; private set; }
        public string LandLordPhoneNumber { get; private set; }

        public Record(
            PremisesType typeOfPremises,
            string address,
            int square,
            int numberOfRooms,
            double price,
            string landLordName,
            string landLordPhoneNumber)
        {
            ID = CurrentID;
            CurrentID++;
            using (StreamWriter file = new StreamWriter(@".\Resources\ID.txt"))
            {
                file.Write(CurrentID);
            }

            TypeOfPremises = typeOfPremises;
            Address = address;
            Square = square;
            NumberOfRooms = numberOfRooms;
            Price = price;
            LandLordName = landLordName;
            LandLordPhoneNumber = landLordPhoneNumber;
        }

        public static void LoadCurrentID()
        {
            using (StreamReader file = new StreamReader(@".\Resources\ID.txt"))
            {
                CurrentID = int.Parse(file.ReadLine());
            }
        }
    }
}