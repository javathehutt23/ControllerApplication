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
    public partial class CustomerListForm : Form
    {
        public List<Customer> CustomerList = new List<Customer>();
        Controller controller = new Controller();

        public CustomerListForm()
        {
            InitializeComponent();
            FormLoad();
        }
        // add a if statement, making sure the edit isn't called without a user selected
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string a = lsbCustomerList.GetItemText(lsbCustomerList.SelectedItem);
                string[] b = a.Split(',');
                int CustomerId = 0;
                try { CustomerId = Int32.Parse(b[0]); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                EditCustomerForm editCustomerForm = new EditCustomerForm(CustomerId);
                editCustomerForm.ReloadForm += RefreshList;
                editCustomerForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a customer");
            }
        }

        public void FormLoad()
        {
            lsbCustomerList.Items.Clear();
            /*Customer customer1 = new Customer(1, "John Schmit", "0216516123", true);

            EverydayAccount everydayAccount = new EverydayAccount(customer1, 1, 400);
            customer1.EverydayAccount.Add(everydayAccount);
            OmniAccount omniAccount = new OmniAccount(customer1, 1, 400, 1000);
            customer1.OmniAccount.Add(omniAccount);
            InvestmentAccount investmentAccount = new InvestmentAccount(customer1, 1, 750);
            customer1.InvestmentAccount.Add(investmentAccount);
            
            Console.WriteLine(customer1.EverydayAccount.Count);

            CustomerList.Add(customer1);*/

            controller.DeSerializeNow();

            CustomerList = controller.CustomerList;
            //controller.CustomerList = Customer.CustomerList;
            foreach (Customer c in controller.CustomerList)
            {
                lsbCustomerList.Items.Add(c.CustomerId + ", " + c.Name);
            }
            //lsbCustomerList.SelectedIndex = 0;
            //controller.SerializeNow();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this Customer?";
            var messagebox1 = MessageBox.Show(message, "Delete Customer", MessageBoxButtons.YesNo);
            if (messagebox1 == DialogResult.Yes)
            {
                CustomerList = Customer.CustomerList;

                string a = lsbCustomerList.GetItemText(lsbCustomerList.SelectedItem);
                string[] b = a.Split(',');
                int CustomerId = 0;
                try { CustomerId = Int32.Parse(b[0]); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                controller.DeleteCustomer(CustomerId);
                RefreshList();
            }
        }

        private void btnAddCustomer_click(object sender, EventArgs e)
        {
            Customer.CustomerList = CustomerList;
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ReloadForm += RefreshList;
            addCustomerForm.ShowDialog(this);
        }

        public void RefreshList()
        {
            CustomerList = Customer.CustomerList;
            lsbCustomerList.Items.Clear();
            foreach(Customer c in Customer.CustomerList)
            {
                lsbCustomerList.Items.Add(c.CustomerId +", " + c.Name);
            }
        }

        private void BtnViewAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                string a = lsbCustomerList.GetItemText(lsbCustomerList.SelectedItem);
                Console.WriteLine("customer" + a);
                string[] b = a.Split(',');
                int CustomerId = 0;
                try { CustomerId = Int32.Parse(b[0]); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                CustomerAccountForm customerAccountForm = new CustomerAccountForm(CustomerId);
                //customerAccountForm.ReloadForm += RefreshList;
                customerAccountForm.Show(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Please select a customer");

            }
        }
    }
}
