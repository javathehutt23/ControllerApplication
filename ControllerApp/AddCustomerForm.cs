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
    public partial class AddCustomerForm : Form
    {
        Controller controller = new Controller();
        public AddCustomerForm()
        {
            InitializeComponent();
            
        }
        public event Action ReloadForm;
        private void btnSave_Click(object sender, EventArgs e)
        {
            controller.AddCustomer(tbxName.Text,tbxContactDetails.Text);
            MessageBox.Show("customer added.");
            this.Close();
            ReloadForm();
            //CustomerListForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
