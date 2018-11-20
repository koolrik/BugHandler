using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\BugHandler.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Role from Login where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "' ",con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                BugHandlerEntities bte = new BugHandlerEntities();
                var role = bte.Logins.Where(a => a.Username == textBox1.Text).SingleOrDefault();
                if(role.Role=="admin")
                {
                    BugHandlerSoftware bhs = new BugHandlerSoftware();
                    this.Hide();
                    bhs.Show();
                }
                else if (role.Role == "Client")
                {

                }
                else
                {

                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
