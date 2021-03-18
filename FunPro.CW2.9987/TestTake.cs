using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunPro.CW2._9987.DAL;

namespace FunPro.CW2._9987
{
    public partial class TestTake : Form
    {
        public TestTake()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Applicants Applicant { get; set; }

        public Tests Test { get; set; }        

        public void ShowTests(string name)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            lblApplicantName.Text = name;                                    
            cbxTestName.DataSource = new TestManager().GetAllTests();            
            Show();
        }

        private void cbxTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var questions = new TestManager().GetQuestionsAndAnswers(cbxTestName.Text);
            lblQuestion1.Text = questions.TestQuestion1;
            lblQuestion2.Text = questions.TestQuestion2;
            lblQuestion3.Text = questions.TestQuestion3;
        }
    }
}
