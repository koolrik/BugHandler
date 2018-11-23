using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginForm
{
    public partial class BugHandlerAdmin : Form
    {
        public SessionModule session { get; set; }
        public BugHandlerAdmin()
        {
            InitializeComponent();
        }

        public BugHandlerAdmin(SessionModule sm)
        {
            InitializeComponent();
            
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugDetail bd = new BugDetail(session);
            bd.MdiParent = this;
            bd.Show();
        }

        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            IWebDriver driver = new ChromeDriver();

            driver.Url = ("https://github.com/login");

            driver.FindElement(By.Id("login_field")).SendKeys("koolrik");
            driver.FindElement(By.Id("password")).SendKeys("Koolrik1590");
          
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            au.MdiParent = this;
            au.Show();
        }
    }
}
