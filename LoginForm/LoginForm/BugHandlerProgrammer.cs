using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
