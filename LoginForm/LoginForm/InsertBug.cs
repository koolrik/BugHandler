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
    public partial class InsertBug : Form
    {
        public SessionModule session { get; set; }
        Image img;

        public InsertBug()
        {
            InitializeComponent();
        }

        public InsertBug(SessionModule sm)
        {
            InitializeComponent();
            session = sm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png |All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    img = Image.FromFile(dialog.FileName);
                    image1.Image = img;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("One or More Fields Are Empty");
            }
            try
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
                BugHandlerEntities1 bte = new BugHandlerEntities1();
                var InsIssue = new Issue
                {
                    Title = textBox1.Text.Trim(),
                    Description = richTextBox1.Text.Trim(),
                    Image = ms.ToArray(),
                    Status = "PENDING",
                    InsertedBy = session.Username
                };
                bte.Issues.Add(InsIssue);
                bte.SaveChanges();
                MessageBox.Show("Issue Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
