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
            //to remove all the unnecessary space
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("One or More Fields Are Empty");
            }
            try
            {
                //using local variable for selecting the role of admin or programmer
                string userrole = "";
                if (checkBox1.Checked)
                {
                    userrole = "Admin";
                }
                else
                {
                    userrole = "Programmer";
                }
                //to insert data in the database table Login
                BugHandlerEntities1 bhe = new BugHandlerEntities1();
                var InsUser = new Login
                {
                    Username = textBox1.Text.Trim(),
                    Password = textBox2.Text.Trim(),
                    Role = userrole
                };
                //to show that the data are stored 
                bhe.Logins.Add(InsUser);
                bhe.SaveChanges();
                MessageBox.Show("User Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //to close the application in the MDI form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
