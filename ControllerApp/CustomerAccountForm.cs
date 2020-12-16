using ControllerApp.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            string a = lsbAccountList.GetItemText(lsbAccountList.SelectedItem);
            string[] accountType = a.Split(' ');
            string type = lblInput.Text; string[] typeList = type.Split(':');
            int AccountId;
            int g;
            if (int.TryParse(txbInputs.Text, g))
            {
                try
                {
                    AccountId = Int32.Parse(accountType[1]);
                    string balance = txbInputs.Text;
                    if (typeList[1] == " Withdraw")
                    {
                        balance = "-" + txbInputs.Text;
                        Console.WriteLine(balance);
                    }
                    Console.WriteLine(typeList[1]);
                    Console.WriteLine(accountType[0]);
                    controller.EditAccountBalance(customer.CustomerId, accountType[0], AccountId, Int32.Parse(balance));
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                RefreshList();
            }
            else
            {
                MessageBox.Show("enter a valid number");
            }
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
            lsbAccountList.SelectedIndex = 0;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AddAccountForm addAccountForm = new AddAccountForm(customer);
            addAccountForm.ShowDialog(this);
            RefreshList();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            lblInput.Text = "Input type: " + "Deposit";
            /*string a = lsbAccountList.GetItemText(lsbAccountList.SelectedItem);
            string[] b = a.Split(' ');
            int AccountId;
            try { AccountId = Int32.Parse(b[1]); controller.DeleteCustomer(AccountId); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            RefreshList();*/
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            lblInput.Text = "Input type: " + "Withdraw";
            /*string a = lsbAccountList.GetItemText(lsbAccountList.SelectedItem);
            string[] b = a.Split(' ');
            int AccountId;
            try { AccountId = Int32.Parse(b[1]); controller.DeleteCustomer(AccountId); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            RefreshList();*/
        }
    }
}
