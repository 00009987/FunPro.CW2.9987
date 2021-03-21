using System;
using System.Windows.Forms;
using FunPro.CW2._9987.DAL;

namespace FunPro.CW2._9987
{
    public partial class ApplicantEditForm : Form
    {
        public ApplicantEditForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // closing the form
            Close();
        }

        // referecing Applicants and FormMode classes
        public Applicants Applicant { get; set; }

        public FormMode Mode { get; set; }

        // method to show the form to create a new applicant
        public void CreateNewApplicant()
        {
            Mode = FormMode.CreateNew;
            Applicant = new Applicants();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        // method to show the form to update information of the applicant
        public void UpdateApplicant(Applicants applicant)
        {
            Mode = FormMode.Update;
            Applicant = applicant;
            ShowApplicantInControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        private void InitializeControls()
        {
        }

        // method to show the information of the applicant in the input fields
        private void ShowApplicantInControls()
        {
            tbxName.Text = Applicant.Name;
            nudScore.Value = Applicant.Score;
            tbxTestTaken.Text = Applicant.TestTaken;
        }

        // method to get the inputs of the user 
        private void GrabUserInput()
        {
            Applicant.Name = tbxName.Text;
            Applicant.Score = Convert.ToInt32(nudScore.Value);
            Applicant.TestTaken = tbxTestTaken.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // saving the user inputs
            try
            {
                GrabUserInput();
                var manager = new ApplicantManager();

                // checking whether to create a new applicant or update the current one
                if (Mode == FormMode.CreateNew) 
                    manager.Create(Applicant);
                else
                    manager.Update(Applicant);

                // loading the list form and closing edit form
                MyForms.GetForm<ApplicantListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                // if something went wrong during the process, show the corresponding error
                MessageBox.Show(ex.Message);
            }

        }        
    }
}
