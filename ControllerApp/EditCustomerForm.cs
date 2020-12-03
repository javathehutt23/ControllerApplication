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
    public partial class EditCustomerForm : Form
    {
        Controller controller = new Controller();
        public event Action ReloadForm;
        public EditCustomerForm(int a)
        {
            InitializeComponent();
            controller.CustomerList = Customer.CustomerList;
            Customer c = controller.FindCustomerById(a);
            txbName.Text = c.Name; txbContactDetails.Text = c.ContactDetails; cbxStaff.Checked = c.IsStaff; lblCustomerID.Text = "ID: " + c.CustomerId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string a = lblCustomerID.Text;
            string[] b = a.Split(':');
            int CustomerId = 0;
            try { CustomerId = Int32.Parse(b[1]); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            controller.EditCustomer(CustomerId, txbName.Text, txbContactDetails.Text, cbxStaff.Checked);
            MessageBox.Show("customer edited.");
            this.Close();
            ReloadForm();
        }
    }
}
