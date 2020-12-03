using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
