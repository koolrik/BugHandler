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
    public partial class BugHandlerSoftware : Form
    {
        public SessionModule session { get; set; }
        public BugHandlerSoftware()
        {
            InitializeComponent();
        }

        public BugHandlerSoftware(SessionModule xyz)
        {
            InitializeComponent();
            session = xyz;
        }

        private void insertBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertBug cde = new InsertBug(session);
            cde.MdiParent = this;
            cde.Show();
        }

        private void solutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugSolution bs = new BugSolution(session);
            bs.MdiParent = this;
            bs.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 ghj = new Form1();
            this.Hide();
            ghj.Show();
        }

        private void viewOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = ("https://github.com/login");

            driver.FindElement(By.Id("login_field")).SendKeys("koolrik");
            driver.FindElement(By.Id("password")).SendKeys("Koolrik1590");
        }
    }
}
