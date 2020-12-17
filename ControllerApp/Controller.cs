using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerApp
{
/// <summary>
/// The main Controller class.
/// Contains all the methods for performing customer, account and transactions processing activities,
/// including create, update and delete actions on all three objects types.
/// The Controller supports all the three different account types.
/// The Controller also provides for serialising to persistent storage of all of the objects used by the application,
/// and supports the deserialising and loading of all objects from persistent storage used in the application.
/// </summary>
  class Controller
    {
<<<<<<< Updated upstream
        public List<Customer> CustomerList = Customer.CustomerList;

        public void AddCustomer(string customerName, string contactDetails)
=======
/// <value> List of Customer objects currently being used by the application.</value>
	public List<Customer> CustomerList = Customer.CustomerList;
/// <remarks>
/// This function adds a Customer to the customer list.
/// </remarks>
/// <param name="customerName">A string containing Name including spaces.</param>
/// <param name="contactDetails">A string containing contact details.</param>
/// <param name="contactStaff">A string containing staff contact details.</param>
        public void AddCustomer(string customerName, string contactDetails, bool contactStaff)
>>>>>>> Stashed changes
        {
            CustomerList = Customer.CustomerList;
            int i = 1;
            foreach( Customer c in CustomerList)
            {
                if (c.CustomerId == i) { i++; }
                else { break; }
            }
            CustomerList.Add(new Customer(i, customerName, contactDetails));
            Customer.CustomerList = CustomerList;
        }
/// <remarks>
/// This function deletes a Customer from the customer list.
/// </remarks>
/// <param name="csutomerId">A integer customerId.</param>
        public void DeleteCustomer(int customerId)
        {
            
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            foreach (Customer c in CustomerList)
            {
                if(c == customer) { CustomerList.Remove(c); Customer.CustomerList = CustomerList; break; }
            }
        }
<<<<<<< Updated upstream

        public void EditCustomer(int customerId, string customerName, string contactDetails)
=======
/// <remarks>
/// This function edits a Customer in the customer list.
/// </remarks>
/// <param name="customerName">A string containing Name including spaces.</param>
/// <param name="contactDetails">A string containing contact details.</param>
/// <param name="contactStaff">A string containing staff contact details.</param>
        public void EditCustomer(int customerId, string customerName, string contactDetails, bool contactStaff)
>>>>>>> Stashed changes
        {
            Customer customer = FindCustomerById(customerId);
            foreach (Customer c in CustomerList)
            {
                if (c.CustomerId == customerId) { c.Name = customerName; c.ContactDetails = contactDetails; Customer.CustomerList = CustomerList; }
            }
        }
/// <remarks>
/// This function finds a Customer by customerId.
/// </remarks>
/// <param name="csutomerId">A integer customerId.</param>
        public Customer FindCustomerById(int customerId)
        {
            foreach (Customer c in CustomerList)
            {
                if (c.CustomerId == customerId) { return c; }
            }
            return null;  
        }
<<<<<<< Updated upstream

=======
/// <remarks>
/// This function updates a customer Account balance for all of the account types.
/// </remarks>
/// <param name="customerId">A interger customerId.</param>
/// <param name="accountType">A string containing accountType.</param>
/// <param name="accountId">A integer accountId.</param>
/// <param name="amount">A float containing the transaction amount.</param>
        public bool EditAccountBalance(int customerId, string accountType, int accountId, float amount)
        {
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            if(accountType == "Everyday")
            {
                int index = customer.EverydayAccount.FindIndex(item => item.AccountId == accountId);
                if ((customer.EverydayAccount[index].Balance + amount) < 0)
                {
                    MessageBox.Show("failed transaction, tried to take out too much"); SerializeNow(); return false;
                }
                customer.EverydayAccount[index].Balance += amount;
                Console.WriteLine(customer.EverydayAccount[index].Balance);
                Customer.CustomerList = CustomerList;
            }
            else if(accountType == "Investment"){
                int index = customer.InvestmentAccount.FindIndex(item => item.AccountId == accountId);
                if ((customer.InvestmentAccount[index].Balance + amount) < 0)
                {
                    if (customer.InvestmentAccount[index].Balance > customer.InvestmentAccount[index].Fees)
                    {
                        if (customer.IsStaff)
                        {
                            customer.InvestmentAccount[index].Balance -= (customer.InvestmentAccount[index].Fees/2);
                        }
                        else
                        {
                            customer.InvestmentAccount[index].Balance -= customer.InvestmentAccount[index].Fees;
                        }
                    }
                    Customer.CustomerList = CustomerList;
                    MessageBox.Show("failed transaction, tried to take out too much, fee incurred"); SerializeNow(); return false;
                }
                customer.InvestmentAccount[index].Balance += amount;
                Customer.CustomerList = CustomerList;
            }
            else if(accountType == "Omni")
            {
                int index = customer.OmniAccount.FindIndex(item => item.AccountId == accountId);
                if ((customer.OmniAccount[index].Balance + amount) < 0)
                {
                    if((customer.OmniAccount[index].Balance + customer.OmniAccount[index].OverdraftLimit) < customer.OmniAccount[index].Fees)
                    {
                        if (customer.OmniAccount[index].Balance > customer.OmniAccount[index].Fees)
                        {
                            if (customer.IsStaff)
                            {
                                customer.OmniAccount[index].Balance -= (customer.OmniAccount[index].Fees/2);
                            }
                            else
                            {
                                customer.OmniAccount[index].Balance -= customer.OmniAccount[index].Fees;
                            }
                        }
                        Customer.CustomerList = CustomerList;
                        MessageBox.Show("failed transaction, overdraft limit reached, Fee Incurred"); SerializeNow(); return false;
                    }
                    else
                    {
                        //customer.OmniAccount[index].Balance -= customer.OmniAccount[index].Fees;
                        float a = customer.OmniAccount[index].Balance + customer.OmniAccount[index].OverdraftLimit;
                        a += amount;
                        customer.OmniAccount[index].Balance += amount;
                        Customer.CustomerList = CustomerList;
                        MessageBox.Show("You used your overdraft: $" + a + " Remaining"); SerializeNow(); return false;
                    }
                }
                customer.OmniAccount[index].Balance += amount;
                Customer.CustomerList = CustomerList;
                SerializeNow();
                return true;
            }
            SerializeNow();
            return true;
        }
/// <remarks>
/// This function adds n Account for a Customer and sets the intial balance and over draft limit.
/// </remarks>
/// <param name="customerId">A interger customerId.</param>
/// <param name="accountType">A string containing accountType.</param>
/// <param name="balance">A float amount for the initial balance.</param>
/// <param name="overdraft">A float amount for the initial overdraft limit amount.</param>        
		public void AddAccount(int customerId, string accountType, float balance, float overdraft)
        {
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            int i = 1;
            if (accountType == "Everyday")
            {  
                foreach (EverydayAccount e in customer.EverydayAccount)
                {
                    if (e.AccountId == i) { i++; }
                    else { break; }
                }
                EverydayAccount everyday = new EverydayAccount(customer, i, balance);
                customer.EverydayAccount.Add(everyday);
                Customer.CustomerList = CustomerList;
            }
            else if (accountType == "Investment")
            {
                foreach (InvestmentAccount e in customer.InvestmentAccount)
                {
                    if (e.AccountId == i) { i++; }
                    else { break; }
                }
                InvestmentAccount investment = new InvestmentAccount(customer, i, balance);
                customer.InvestmentAccount.Add(investment);
                Customer.CustomerList = CustomerList;
            }
            else if (accountType == "Omni")
            {
                foreach (OmniAccount e in customer.OmniAccount)
                {
                    if (e.AccountId == i) { i++; }
                    else { break; }
                }
                OmniAccount omni = new OmniAccount(customer, i, balance, overdraft);
                customer.OmniAccount.Add(omni);
                Customer.CustomerList = CustomerList;
            }
            SerializeNow();
        }
/// <remarks>
/// This function transfers funds between two accounts and manages the transfer limits and overdraft limit.
/// </remarks>
/// <param name="customerId">A interger customerId.</param>
/// <param name="takefromAccountId">A integer accountId for the account to take from.</param>
/// <param name="givetoAccountId">A integer accountId for the account to give to.</param>
/// <param name="takeFromType">A string for the take transfer type.</param>
/// <param name="giveToType">A string for the give transfer type.</param>
/// <param name="amount">A float containing the transaction amount.</param>
        public void TransferAccountAmount(int customerId, int takeFromAccountId, int giveToAccountId, string takeFromType, string giveToType, float amount)
        {
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            float oppositeAmount = (amount - (amount * 2));
            if(EditAccountBalance(customerId, takeFromType, takeFromAccountId, oppositeAmount))
            {
                EditAccountBalance(customerId, giveToType, giveToAccountId, amount);
                MessageBox.Show("Transfer successfull");
            }

        }
/// <remarks>
/// This function adds interest to a customer Omni and Investment accounts.
/// </remarks>
/// <param name="customerId">A interger customerId.</param>
/// <param name="AccountType">A string Account Type.</param>
/// <param name="accountId">A integer accountId.</param>
        public void AddInterest(int customerId, string accountType, int accountId)
        {
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            if(accountType == "Everyday")
            {
                MessageBox.Show("This account doesn't support interest calculations");
                return;
            }
            else if(accountType == "Investment")
            {
                int index = customer.InvestmentAccount.FindIndex(item => item.AccountId == accountId);
                //float interestValue = (customer.InvestmentAccount[index].InterestRate/100) + 1;
                customer.InvestmentAccount[index].CalculateInterest();
                //customer.InvestmentAccount[index].Balance += (customer.InvestmentAccount[index].Balance * interestValue);
                MessageBox.Show("Calculated interest has been added");
            }
            else if(accountType == "Omni")
            {
                int index = customer.OmniAccount.FindIndex(item => item.AccountId == accountId);
                customer.OmniAccount[index].CalculateInterest();
                //float interestValue = (customer.OmniAccount[index].InterestRate / 100) + 1;
                //customer.OmniAccount[index].Balance += (customer.OmniAccount[index].Balance * interestValue);
                MessageBox.Show("Calculated interest has been added");
            }
            Customer.CustomerList = CustomerList;
            SerializeNow();
        }
/// <remarks>
/// This function serialises all of the current Customer and Account objects and writes them out to external persistent storage.
/// </remarks>
/// <exception cref="System.IOException">Thrown when unable to serialise the current Customer List objetcs and all other linked objects.</exception>
        public void SerializeNow()
        {
            CustomerList = Customer.CustomerList;
            var cList = CustomerList;
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, cList);
                }
            }
            catch (IOException)
            {
            }

        }
/// <remarks>
/// This function deserialises and loads all of the Customer and Account objects held in external persistent storage.
/// </remarks>
/// <exception cref="System.IOException">Thrown when unable to deserialise the current external file into the Customer List objects and all other linked 
/// objects.</exception>

        public void DeSerializeNow()
        {
            CustomerList = Customer.CustomerList;
            try
                    {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    CustomerList = (List<Customer>)bin.Deserialize(stream);
                    Customer.CustomerList = CustomerList;
                }
            }
            catch (IOException)
            {
            }
        }
>>>>>>> Stashed changes
    }
}
