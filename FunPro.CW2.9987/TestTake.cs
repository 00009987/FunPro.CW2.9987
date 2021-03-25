using System;
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
            // closing the form
            Close();
        }

        // declearing global variables to store test takers data
        private int applicantId;
        private int applicantScore;
        private string applicantTests;
        private string currentTest;
        
        public void ShowTests(string name, int id, int score, string takenTests)
        {
            // setting private global variables to the parameters of the test taker
            applicantId = id;
            applicantScore = score;
            applicantTests = takenTests;
            currentTest = cbxTestName.Text;

            // showing the TestTake form
            MdiParent = MyForms.GetForm<ParentForm>();
            // setting user's name to label
            lblApplicantName.Text = name;

            // setting datasource to the test combobox
            cbxTestName.DataSource = new TestManager().GetAllTests();            

            Show();            
        }

        private void cbxTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // changing questions according to the selected test name
            var questions = new TestManager().GetQuestionsAndAnswers(cbxTestName.Text);
            lblQuestion1.Text = questions.Question1;
            lblQuestion2.Text = questions.Question2;
            lblQuestion3.Text = questions.Question3;

            // seting current test on change
            currentTest = cbxTestName.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxAnswer1.Text) || string.IsNullOrEmpty(tbxAnswer2.Text) || string.IsNullOrEmpty(tbxAnswer3.Text))
            {
                MessageBox.Show("Answer input cannot be empty");
            }
            else
            {
                // checking answers and updating applicant's score
                int points = CheckAnswers();
                applicantScore += points;
                new ApplicantManager().UpdateScore(applicantId, applicantScore);

                // updating taken tests of the user
                applicantTests += currentTest + ", ";
                new ApplicantManager().UpdateTestTaken(applicantId, applicantTests);

                // showing how many points user got and refreshing applicant list form
                MessageBox.Show($"You solved {points} questions correctly, and gained {points} points.\n\n" +
                    $"To see the updated information, please click on Refresh.");
                Close();
            }            
        }

        // method to check answers of the users with the correct ones
        public int CheckAnswers()
        {
            var answers = new TestManager().GetQuestionsAndAnswers(cbxTestName.Text);
            int point = 0;

            if(tbxAnswer1.Text == answers.Answer1)
            {
                point++;
            }
            
            if(tbxAnswer2.Text == answers.Answer2)
            {
                point++;
            }
            
            if (tbxAnswer3.Text == answers.Answer3){
                point++;
            }                    

            return point;
        }
    }
}
