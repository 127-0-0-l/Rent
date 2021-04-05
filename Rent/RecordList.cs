using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Rent
{
    static class RecordList
    {
        static public List<Record> Records { get; private set; } = new List<Record>();

        static public void AddRecord(Record record)
        {
            Records.Add(record);
        }

        static public void DeleteRecord(Record record)
        {
            Records.Remove(record);
        }

        static public void LoadRecords()
        {
            using (StreamReader file = new StreamReader(@".\Resources\Records.txt"))
            {
                Records = JsonConvert.DeserializeObject<List<Record>>(file.ReadToEnd());
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