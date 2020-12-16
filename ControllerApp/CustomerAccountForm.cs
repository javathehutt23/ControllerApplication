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
            if (lblInput.Text != "Withdraw" && lblInput.Text == "Deposit")
            {
                MessageBox.Show("Please select a transaction type!"); return;
            }
            int AccountId = 0;
            int balance = 0;
            string balanceText= txbInputs.Text;
            if (txbInputs.Text.Contains("-"))
            {
                MessageBox.Show("you cannot type in a negative number"); return;
            }
            try
            {
                AccountId = Int32.Parse(accountType[1]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); MessageBox.Show("Please select an account"); return; }

            if (typeList[1] == " Withdraw")
            {
                balanceText = "-" + txbInputs.Text;
                Console.WriteLine(balance);
            }
            Console.WriteLine(typeList[1]);
            Console.WriteLine(accountType[0]);
            try
            {
                balance = Int32.Parse(balanceText);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); MessageBox.Show("Please type a number into the input"); return; }
             
            controller.EditAccountBalance(customer.CustomerId, accountType[0], AccountId, balance);
            RefreshList();
            
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
            AddAccountForm addAccountForm = new AddAccountForm(customer.CustomerId);
            addAccountForm.ShowDialog(this);
            RefreshList();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            lblInput.Text = "Input type: " + "Deposit";
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            lblInput.Text = "Input type: " + "Withdraw";
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            TransferAccountForm transferAccountForm = new TransferAccountForm(customer.CustomerId);
            transferAccountForm.ShowDialog(this);
            RefreshList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInterest_Click(object sender, EventArgs e)
        {
            string a = lsbAccountList.GetItemText(lsbAccountList.SelectedItem);
            string[] accountType = a.Split(' ');
            int accountId = 0;
            try { accountId = Int32.Parse(accountType[1]); }
            catch (Exception ex)
            {
                MessageBox.Show("Please select an account"); 
                return;
            }
            controller.AddInterest(customer.CustomerId, accountType[0], accountId);
            RefreshList();
        }
    }
}
