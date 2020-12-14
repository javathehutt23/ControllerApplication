using ControllerApp.Accounts;
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
        private bool isStaff;
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

        public bool IsStaff
        {
            get { return isStaff; }
            set { isStaff = value; }
        }

        public List<EverydayAccount> EverydayAccount = new List<EverydayAccount>();
        public List<InvestmentAccount> InvestmentAccount = new List<InvestmentAccount>();
        public List<OmniAccount> OmniAccount = new List<OmniAccount>();

        public Customer(int customerId, string name, string contactDetails, bool isStaff)
        {
            this.customerId = customerId;
            this.name = name;
            this.contactDetails = contactDetails;
            this.isStaff = isStaff;
        }
        
    }
}

