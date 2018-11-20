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
    }
}
