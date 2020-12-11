using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audiobook_Library_PA_6
{   // Main form that requires the user to enter their CWID into the form to pull up a list of books
    public partial class frmCWID : Form
    {
        public frmCWID()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the program, if the user wishes to
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hides this form
            frmMain myForm = new frmMain(txtCWID.Text); // Transfers the CWID over to the new main form
            if (myForm.ShowDialog() == DialogResult.OK) // If it works, continue
            {

            }

            else // Else, exit
            {
                this.Close();
            }
        }
    }
}
