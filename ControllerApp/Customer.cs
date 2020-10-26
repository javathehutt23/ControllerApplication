using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp
{
    public class Customer
    {
        public static List<Customer> CustomerList = new List<Customer>();
        private int customerId;
        private string name;
        private string contactDetails;
        //private List<Account> customerAccount;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ContactDetails
        {
            get { return contactDetails; }
            set { contactDetails = value; }
        }
        //ContactDetails contactDetails = new ContactDetails();

        public List<Account> CustomerAccount = new List<Account>();


        public Customer(int customerId, string name, string contactDetails)
        {
            this.customerId = customerId;
            this.name = name;
            this.contactDetails = contactDetails;

        }

    }
}

