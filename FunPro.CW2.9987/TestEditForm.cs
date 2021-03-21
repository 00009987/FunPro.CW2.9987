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
    public partial class TestEditForm : Form
    {
        public TestEditForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // closing the form
            Close();
        }

        // referecing Tests and FormMode classes
        public Tests Test { get; set; }

        public FormMode Mode { get; set; }

        // method to show the form to create a new test
        public void CreateNewTest()
        {
            Mode = FormMode.CreateNew;
            Test = new Tests();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        // method to show the form to update data of the test
        public void UpdateTest(Tests test)
        {
            Mode = FormMode.Update;
            Test = test;
            ShowTestInControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        private void InitializeControls()
        {
        }

        // method to show the information of the test in the input fields
        private void ShowTestInControls()
        {
            tbxName.Text = Test.TestName;
            tbxQuestion1.Text = Test.TestQuestion1;
            tbxAnswer1.Text = Test.TestQuestion1Answer;
            tbxQuestion2.Text = Test.TestQuestion2;
            tbxAnswer2.Text = Test.TestQuestion2Answer;
            tbxQuestion3.Text = Test.TestQuestion3;
            tbxAnswer3.Text = Test.TestQuestion3Answer;
        }

        // method to get the inputs of the user 
        private void GrabUserInput()
        {
            Test.TestName = tbxName.Text;
            Test.TestQuestion1 = tbxQuestion1.Text;
            Test.TestQuestion1Answer = tbxAnswer1.Text;
            Test.TestQuestion2 = tbxQuestion2.Text;
            Test.TestQuestion2Answer = tbxAnswer2.Text;
            Test.TestQuestion3 = tbxQuestion3.Text;
            Test.TestQuestion3Answer = tbxAnswer3.Text;
        }        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // saving the user inputs
            try
            {
                GrabUserInput();
                var manager = new TestManager(); 

                // checking if the new test is going to be created 
                //and test name is not already occupied in the database
                if (Mode == FormMode.CreateNew && manager.CheckTestName(Test.TestName))
                {
                    manager.Create(Test);
                }

                // checking if the test is going to be updated
                else if(manager.CheckTestName(Test.TestName))
                {                    
                   manager.Update(Test);
                }
                else
                {
                    // if something went wrong during the checking process, show the corresponding error
                    MessageBox.Show("This name of the test already exists in the database. Please try another name.");
                }

                // loading the list form and closing edit form
                MyForms.GetForm<TestListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                // if something went wrong during the saving process, show the corresponding error
                MessageBox.Show(ex.Message);
            }
        }

        private void TestEditForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
        }
    }
}
