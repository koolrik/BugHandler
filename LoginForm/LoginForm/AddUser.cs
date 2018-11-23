using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("One or More Fields Are Empty");
            }
            try
            {
                string userrole = "";
                if (checkBox1.Checked)
                {
                    userrole = "Admin";
                }
                else
                {
                    userrole = "Programmer";
                }
                BugHandlerEntities1 bhe = new BugHandlerEntities1();
                var InsUser = new Login
                {
                    Username = textBox1.Text.Trim(),
                    Password = textBox2.Text.Trim(),
                    Role=userrole
                };
                bhe.Logins.Add(InsUser);
                bhe.SaveChanges();
                MessageBox.Show("User Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
