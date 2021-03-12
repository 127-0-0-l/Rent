using System.Collections.Generic;

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
    }
}