using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp
{
    class ContactDetails
    {
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private int phoneNumber;
        public int PhoneNumber
        {
            get { return phoneNumber;}
            set { phoneNumber = value; }
        }
    }
}
