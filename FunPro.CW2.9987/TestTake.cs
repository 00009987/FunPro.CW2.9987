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

        private int applicantId;
        private int applicantScore;

        public Applicants Applicant { get; set; }

        public Tests Test { get; set; }        

        public void ShowTests(string name, int id, int score)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            lblApplicantName.Text = name;                                    
            cbxTestName.DataSource = new TestManager().GetAllTests();            
            Show();

            applicantId = id;
            applicantScore = score;
        }

        private void cbxTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var questions = new TestManager().GetQuestionsAndAnswers(cbxTestName.Text);
            lblQuestion1.Text = questions.TestQuestion1;
            lblQuestion2.Text = questions.TestQuestion2;
            lblQuestion3.Text = questions.TestQuestion3;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // checking answers and updating applicant's score
            int points = CheckAnswers();
            applicantScore += points;
            new ApplicantManager().UpdateScore(applicantId, applicantScore);

            // showing how many points user got and refreshing applicant list form
            MessageBox.Show($"You solved {points} questions correctly, and gained {points} points.\n" +
                $"To see the updated scores, please click on Refresh.");
            Close();                 
        }

        // method to check answers of the users with the correct ones
        public int CheckAnswers()
        {
            var answers = new TestManager().GetQuestionsAndAnswers(cbxTestName.Text);
            int point = 0;

            if(tbxAnswer1.Text == answers.TestQuestion1Answer)
            {
                point++;
            }
            
            if(tbxAnswer2.Text == answers.TestQuestion2Answer)
            {
                point++;
            }
            
            if (tbxAnswer3.Text == answers.TestQuestion3Answer){
                point++;
            }            

            return point;
        }
    }
}
