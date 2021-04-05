using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Rent
{
    static class RecordList
    {
        static public List<Record> Records { get; private set; }

        static public void AddRecord(Record record)
        {
            Records.Add(record);

            using (StreamWriter file = new StreamWriter(@".\Resources\History", true))
            {
                string str =
                    $"\nAdd new record. Record info:" +
                    $"\nID: {record.ID}" +
                    $"\nTypeOfPremises: {record.TypeOfPremises}" +
                    $"\nAddress: {record.Address}" +
                    $"\nSquare: {record.Square}" +
                    $"\nNumberOfRooms: {record.NumberOfRooms}" +
                    $"\nPrice: {record.Price}" +
                    $"\nLandLordName: {record.LandLordName}" +
                    $"\nLandLordPhoneNumber: {record.LandLordPhoneNumber}" +
                    $"\n\n";

                file.Write(str);
            }
        }

        static public void DeleteRecord(int id)
        {
            var record = Records.Where(o => o.ID == id).FirstOrDefault();

            Records.Remove(record);

            using (StreamWriter file = new StreamWriter(@".\Resources\History", true))
            {
                string str =
                    $"\nDelete record. Record info:" +
                    $"\nID: {record.ID}" +
                    $"\nTypeOfPremises: {record.TypeOfPremises}" +
                    $"\nAddress: {record.Address}" +
                    $"\nSquare: {record.Square}" +
                    $"\nNumberOfRooms: {record.NumberOfRooms}" +
                    $"\nPrice: {record.Price}" +
                    $"\nLandLordName: {record.LandLordName}" +
                    $"\nLandLordPhoneNumber: {record.LandLordPhoneNumber}" +
                    $"\n\n";

                file.Write(str);
            }
        }

        static public void LoadRecords()
        {
            using (StreamReader file = new StreamReader(@".\Resources\Records.txt"))
            {
                Records = JsonConvert.DeserializeObject<List<Record>>(file.ReadToEnd());
            }

            if (Records == null)
            {
                Records = new List<Record>();
            }
        }

        static public void SaveRecords()
        {
            using (StreamWriter file = new StreamWriter(@".\Resources\Records.txt"))
            {
                file.Write(JsonConvert.SerializeObject(Records));
            }
        }
    }
}