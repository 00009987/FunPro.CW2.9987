using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunPro.CW2._9987
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // showing About section
            new AboutForm().ShowDialog();
        }

        private void allApplicantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // showing all applicants
            MyForms.GetForm<ApplicantListForm>().Show();
        }

        private void newApplicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // showing applicant creating/upadting form
            new ApplicantEditForm().CreateNewApplicant();
        }
    }
}
