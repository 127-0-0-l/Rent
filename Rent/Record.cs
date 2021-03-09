using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
