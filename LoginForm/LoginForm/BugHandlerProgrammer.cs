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
        //setting parameters
        public BugHandlerProgrammer(SessionModule sm)
        {
            InitializeComponent();
            session = sm;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //to show the ViewBug Form
        private void viewBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBug di = new ViewBug(session);
            di.MdiParent = this;
            di.Show();
        }
        //to connect to the github online site using saved credentials
        private void viewOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = ("https://github.com/login");

            driver.FindElement(By.Id("login_field")).SendKeys("koolrik");
            driver.FindElement(By.Id("password")).SendKeys("Koolrik1590");
        }
        //to close the application and open the Form1
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 jkl = new Form1();
            this.Hide();
            jkl.Show();
        }
    }
}
