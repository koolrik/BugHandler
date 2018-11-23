using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\BugHandler.mdf;Integrated Security=True;Connect Timeout=30");
            BugHandlerEntities1 bhe = new BugHandlerEntities1();
            var regUser = new Login
            {
                Username = textBox1.Text.Trim(),
                Password = textBox2.Text.Trim(),
                Role = "Client"
            };

            bhe.Logins.Add(regUser);
            bhe.SaveChanges();
            MessageBox.Show("User Saved");

        }
        //close the form and open new form Form1
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
