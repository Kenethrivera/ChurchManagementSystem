using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSAccounts
{
    public class UserAccounts
    {
        private string firstName;
        private string lastName;
        private int age;
        private string emailAddress;
        private string ministryName;
        private string position;
        private string userName;
        private string password;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public string MinistryName
        {
            get { return ministryName; }
            set { ministryName = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }

}
