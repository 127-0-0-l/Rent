using System.Text;
using System.IO;

namespace Rent
{
    static class Report
    {
        public static class Records
        {
            public static string Create()
            {
                StringBuilder str = new StringBuilder();

                foreach (var record in RecordList.Records)
                {
                    str.Append(
                        $"\nID: {record.ID}" +
                        $"\nтип помещения: {record.TypeOfPremises}" +
                        $"\nадрес: {record.Address}" +
                        $"\nплощадь: {record.Square}" +
                        $"\nколичество комнат: {record.NumberOfRooms}" +
                        $"\nцена: {record.Price}" +
                        $"\nимя арендодателя: {record.LandLordName}" +
                        $"\nномер телефона арендодателя: {record.LandLordPhoneNumber}" +
                        $"\n\n");
                }

                return str.ToString();
            }
        }

        public static class Operations
        {
            public static string Create()
            {
                string operations;

                using (StreamReader file = new StreamReader(@".\Resources\History.txt"))
                {
                    operations = file.ReadToEnd();
                }

                return operations;
            }
        }
    }
}