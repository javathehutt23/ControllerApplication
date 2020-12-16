using ControllerApp.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerApp
{
    class Controller
    {
        public List<Customer> CustomerList = Customer.CustomerList;

        public void AddCustomer(string customerName, string contactDetails, bool contactStaff)
        {
            CustomerList = Customer.CustomerList;
            int i = 1;
            foreach( Customer c in CustomerList)
            {
                if (c.CustomerId == i) { i++; }
                else { break; }
            }
            CustomerList.Add(new Customer(i, customerName, contactDetails, contactStaff));
            Customer.CustomerList = CustomerList;
        }

        public void DeleteCustomer(int customerId)
        {
            
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            foreach (Customer c in CustomerList)
            {
                if(c == customer) { CustomerList.Remove(c); Customer.CustomerList = CustomerList; break; }
            }
        }

        public void EditCustomer(int customerId, string customerName, string contactDetails, bool contactStaff)
        {
            Customer customer = FindCustomerById(customerId);
            foreach (Customer c in CustomerList)
            {
                if (c.CustomerId == customerId) { c.Name = customerName; c.ContactDetails = contactDetails; c.IsStaff = contactStaff; Customer.CustomerList = CustomerList; }
            }
        }

        public Customer FindCustomerById(int customerId)
        {
            foreach (Customer c in CustomerList)
            {
                if (c.CustomerId == customerId) { return c; }
            }
            return null;  
        }

        public bool EditAccountBalance(int customerId, string accountType, int accountId, float amount)
        {
            CustomerList = Customer.CustomerList;
            Customer customer = FindCustomerById(customerId);
            if(accountType == "Everyday")
            {
                int index = customer.EverydayAccount.FindIndex(item => item.AccountId == accountId);
                if ((customer.EverydayAccount[index].Balance + amount) < 0)
                {
                    MessageBox.Show("failed transaction, tried to take out too much"); return false;
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
                        customer.InvestmentAccount[index].Balance -= customer.InvestmentAccount[index].Fees;
                    }
                    Customer.CustomerList = CustomerList;
                    MessageBox.Show("failed transaction, tried to take out too much, fee incurred"); return false;
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
                            customer.OmniAccount[index].Balance -= customer.OmniAccount[index].Fees;
                        }
                        Customer.CustomerList = CustomerList;
                        MessageBox.Show("failed transaction, overdraft limit reached, Fee Incurred"); return false;
                    }
                    else
                    {
                        //customer.OmniAccount[index].Balance -= customer.OmniAccount[index].Fees;
                        float a = customer.OmniAccount[index].Balance + customer.OmniAccount[index].OverdraftLimit;
                        a += amount;
                        customer.OmniAccount[index].Balance += amount;
                        Customer.CustomerList = CustomerList;
                        MessageBox.Show("You used your overdraft: $" + a + " Remaining"); return false;
                    }
                }
                customer.OmniAccount[index].Balance += amount;
                Customer.CustomerList = CustomerList;
                return true;
            }
            return true;
        }

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
        }

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

    }
}
