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

            using (StreamWriter file = new StreamWriter(@".\Resources\History.txt", true))
            {
                string str =
                    $"\nДобавлена новая запись. Информация:" +
                    $"\nID: {record.ID}" +
                    $"\nтип помещения: {record.TypeOfPremises}" +
                    $"\nадрес: {record.Address}" +
                    $"\nплощадь: {record.Square}" +
                    $"\nколичество комнат: {record.NumberOfRooms}" +
                    $"\nцена: {record.Price}" +
                    $"\nимя арендодателя: {record.LandLordName}" +
                    $"\nномер телефона арендодателя: {record.LandLordPhoneNumber}" +
                    $"\n\n";

                file.Write(str);
            }
        }

        static public void DeleteRecord(int id)
        {
            var record = Records.Where(o => o.ID == id).FirstOrDefault();

            Records.Remove(record);

            using (StreamWriter file = new StreamWriter(@".\Resources\History.txt", true))
            {
                string str =
                    $"\nУдалена запиь. Информация:" +
                    $"\nID: {record.ID}" +
                    $"\nтип помещения: {record.TypeOfPremises}" +
                    $"\nадрес: {record.Address}" +
                    $"\nплощадь: {record.Square}" +
                    $"\nколичество комнат: {record.NumberOfRooms}" +
                    $"\nцена: {record.Price}" +
                    $"\nимя арендодателя: {record.LandLordName}" +
                    $"\nномер телефона арендодателя: {record.LandLordPhoneNumber}" +
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