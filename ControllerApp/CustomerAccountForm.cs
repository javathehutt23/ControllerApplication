using ControllerApp.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerApp
{
    public partial class CustomerAccountForm : Form
    {
        public List<Customer> CustomerList = new List<Customer>();
        Controller controller = new Controller();
        Customer customer;
        public CustomerAccountForm(int a)
        {
            InitializeComponent();
            controller.CustomerList = Customer.CustomerList;
            customer = controller.FindCustomerById(a);
            lblCustomer.Text = customer.CustomerId + "  " + customer.Name;
            RefreshList();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
        public void RefreshList()
        {
            CustomerList = Customer.CustomerList;
            lsbAccountList.Items.Clear();
            foreach (EverydayAccount e in customer.EverydayAccount)
            {
                lsbAccountList.Items.Add("Everyday " + e.AccountId + " $" + e.Balance);
            }
            foreach (InvestmentAccount e in customer.InvestmentAccount)
            {
                lsbAccountList.Items.Add("Investment " + e.AccountId + " $" + e.Balance);
            }
            foreach (OmniAccount e in customer.OmniAccount)
            {
                lsbAccountList.Items.Add("Omni " + e.AccountId + " $" + e.Balance);
            }
        }
    }
}
