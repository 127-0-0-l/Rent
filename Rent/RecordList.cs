using System.Collections.Generic;

namespace Rent
{
    class RecordList
    {
        public List<Record> Records { get; private set; } = new List<Record>();

        public void AddRecord(Record record)
        {
            Records.Add(record);
        }

        public void DeleteRecord(Record record)
        {
            Records.Remove(record);
        }
    }
}