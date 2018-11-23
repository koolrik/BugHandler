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
    public partial class BugHandlerProgrammer : Form
    {
        public SessionModule session { get; set; }

        public BugHandlerProgrammer()
        {
            InitializeComponent();
        }

        public BugHandlerProgrammer(SessionModule sm)
        {
            InitializeComponent();
            session = sm;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBug di = new ViewBug(session);
            di.MdiParent = this;
            di.Show();
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
            Form1 jkl = new Form1();
            this.Hide();
            jkl.Show();
        }
    }
}
