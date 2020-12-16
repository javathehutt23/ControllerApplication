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
    public partial class AddAccountForm : Form
    {
        public List<Customer> CustomerList = new List<Customer>();
        Controller controller = new Controller();
        Customer customer;
        public AddAccountForm(Customer customer)
        {
            InitializeComponent();
            CustomerList = Customer.CustomerList;
            this.customer = customer;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            float overdraft = 0;
            float balance = 0;
            if (cbxType.Text == "Omni")
            {
                try
                {
                    overdraft = Int32.Parse(txbOverdraft.Text);
                    if (overdraft < 0)
                    {
                        MessageBox.Show("Please enter a positive value for the overdraft"); return;
                    }
                }
                catch(Exception ex) { MessageBox.Show("Please type an appropriate value in overdraft");return; }
            }
            else if(cbxType.Text != "Everyday" && cbxType.Text != "Investment")
            {
                MessageBox.Show("Please select a account type"); return;
            }
            try {
                balance = Int32.Parse(txbBalance.Text);
                if (balance < 0)
                {
                    MessageBox.Show("Please enter a positive value for balance"); return;
                }
            }
            catch(Exception ex) { MessageBox.Show("Please type an appropriate value in the balance");return; }
            controller.AddAccount(customer.CustomerId, cbxType.Text, balance, overdraft);
            MessageBox.Show("Account created!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.GetItemText(cbxType.SelectedItem) == "Omni")
            {
                lblOverdraft.Visible = true;
                txbOverdraft.Visible = true;
            }
            else
            {
                lblOverdraft.Visible = false;
                txbOverdraft.Visible = false;
            }
        }
    }
}
