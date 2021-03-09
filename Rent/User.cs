namespace Rent
{
    public class User
    {
        public UserType TypeOfUser { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public User(UserType userType, string name, string phoneNumber, string login, string password)
        {
            TypeOfUser = userType;
            Name = name;
            PhoneNumber = phoneNumber;
            Login = login;
            Password = password;
        }
    }
}