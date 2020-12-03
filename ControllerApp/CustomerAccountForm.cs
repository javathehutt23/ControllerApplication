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
        Controller controller = new Controller();
        public CustomerAccountForm(int a)
        {
            InitializeComponent();
            controller.CustomerList = Customer.CustomerList;
            Customer c = controller.FindCustomerById(a);
            lblCustomer.Text = c.CustomerId + "  " + c.Name;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
