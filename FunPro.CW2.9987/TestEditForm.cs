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
            Close();
        }

        public Tests Test { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewTest()
        {
            Mode = FormMode.CreateNew;
            Test = new Tests();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

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
            try
            {
                GrabUserInput();
                var manager = new TestManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Test);
                else
                    manager.Update(Test);

                MyForms.GetForm<TestListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TestEditForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
        }
    }
}
