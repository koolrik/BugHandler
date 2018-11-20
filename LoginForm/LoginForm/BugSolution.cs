using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class BugSolution : Form
    {
        public SessionModule session { get; set; }
        public BugSolution()
        {
            InitializeComponent();
        }
        public BugSolution(SessionModule sm)
        {
            InitializeComponent();
            session = sm;
            fillComboBox();
        }

        void fillComboBox()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\BugHandler.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand sda = new SqlCommand("Select Title from Issue where InsertedBy='" + session.Username + "'", con);
                sda.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sc = new SqlDataAdapter(sda);
                sc.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Title"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\BugHandler.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("Select * from Issue where Title ='" + comboBox1.Text + "'", con);
            sqlCmd.ExecuteNonQuery();
            SqlDataReader sdr;
            sdr = sqlCmd.ExecuteReader();
            while (sdr.Read())
            {
                string description = (string)sdr["Description"].ToString();
                richTextBox1.Text = description;

                string solution = (string)sdr["Solution"].ToString();
                richTextBox2.Text = solution;

                BugHandlerEntities1 bte = new BugHandlerEntities1();
                var item = bte.Issues.Where(a => a.Title == comboBox1.Text).SingleOrDefault();
                    textBox1.Text = item.Status;
                byte[] arr = item.Image;
                MemoryStream ms = new MemoryStream(arr);
                pictureBox1.Image = Image.FromStream(ms);
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
