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
    public partial class TransferAccountForm : Form
    {
        public List<Customer> CustomerList = new List<Customer>();
        Controller controller = new Controller();
        Customer customer;
        public TransferAccountForm(int customerId)
        {
            InitializeComponent();
            controller.CustomerList = Customer.CustomerList;
            customer = controller.FindCustomerById(customerId);
            CustomerList = Customer.CustomerList;
            RefreshList();
        }
        public void RefreshList()
        {
            cbxTakeFrom.Items.Clear();
            foreach (EverydayAccount e in customer.EverydayAccount)
            {
                cbxTakeFrom.Items.Add("Everyday " + e.AccountId + " $" + e.Balance);
            }
            foreach (InvestmentAccount e in customer.InvestmentAccount)
            {
                cbxTakeFrom.Items.Add("Investment " + e.AccountId + " $" + e.Balance);
            }
            foreach (OmniAccount e in customer.OmniAccount)
            {
                cbxTakeFrom.Items.Add("Omni " + e.AccountId + " $" + e.Balance);
            }
            cbxTakeFrom.Text = "";

            cbxGiveTo.Items.Clear();
            foreach (EverydayAccount everyday in customer.EverydayAccount)
            {
                cbxGiveTo.Items.Add("Everyday " + everyday.AccountId + " $" + everyday.Balance);
            }
            foreach (InvestmentAccount investment in customer.InvestmentAccount)
            {
                cbxGiveTo.Items.Add("Investment " + investment.AccountId + " $" + investment.Balance);
            }
            foreach (OmniAccount omni in customer.OmniAccount)
            {
                cbxGiveTo.Items.Add("Omni " + omni.AccountId + " $" + omni.Balance);
            }
            cbxGiveTo.Text = "";
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string takeFrom = cbxTakeFrom.GetItemText(cbxTakeFrom.SelectedItem);
            string[] takeFromList = takeFrom.Split(' ');
            string giveTo = cbxGiveTo.GetItemText(cbxGiveTo.SelectedItem);
            string[] giveToList = giveTo.Split(' ');

            string takeFromType = takeFromList[0];
            string giveToType = giveToList[0];
            //int takeFromAccountId = takeFromList[1];
            
            int amount = 0;
            string amountText = txbAmount.Text;
            if (txbAmount.Text.Contains("-"))
            {
                MessageBox.Show("you cannot type in a negative number"); return;
            }

            int takeFromAccountId = 0;
            int giveToAccountId = 0;
            try
            {
                takeFromAccountId = Int32.Parse(takeFromList[1]);
                giveToAccountId = Int32.Parse(giveToList[1]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); MessageBox.Show("Please select an account for both text boxes"); return; }

            try
            {
                amount = Int32.Parse(amountText);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); MessageBox.Show("Please type a number in to input"); return; }

            controller.TransferAccountAmount(customer.CustomerId, takeFromAccountId, giveToAccountId, takeFromType, giveToType, amount);
            RefreshList();
        }

        private void cbxTakeFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxGiveTo.Items.Clear();
            foreach (EverydayAccount everyday in customer.EverydayAccount)
            {
                cbxGiveTo.Items.Add("Everyday " + everyday.AccountId + " $" + everyday.Balance);
            }
            foreach (InvestmentAccount investment in customer.InvestmentAccount)
            {
                cbxGiveTo.Items.Add("Investment " + investment.AccountId + " $" + investment.Balance);
            }
            foreach (OmniAccount omni in customer.OmniAccount)
            {
                cbxGiveTo.Items.Add("Omni " + omni.AccountId + " $" + omni.Balance);
            }
            cbxGiveTo.Items.Remove(cbxTakeFrom.GetItemText(cbxTakeFrom.SelectedItem));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
