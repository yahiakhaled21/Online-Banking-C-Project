using System;
namespace Bank
{

    public class Customer
    {
        private string id;
        private string name;
        private string email;
        private string phoneNum;
        private string password;
        private string address;

        public Customer()
        {
        }

        public Customer(string ID, string Name, string Email, string PhoneNum, string Password,
            string Address)
        {
            _ID = ID;
            _Name = Name;
            _Email = Email;
            _PhoneNum = PhoneNum;
            _Password = Password;
            _Address = Address;
        }

        public string _ID
        {
            get { return id; }
            set { id = value; }
        }

        public string _Name
        {
            get { return name; }
            set { name = value; }
        }

        public string _Email
        {
            get { return email; }
            set { email = value; }
        }

        public string _PhoneNum
        {
            get { return phoneNum; }
            set { phoneNum = value; }
        }

        public string _Password
        {
            get { return password; }
            set { password = value; }
        }

        public string _Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
