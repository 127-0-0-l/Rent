using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent
{
    class User
    {
        public UserType TypeOfUser { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public User(UserType userType, string name, string phoneNumber)
        {
            TypeOfUser = userType;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
