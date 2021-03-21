using System;
using System.Windows.Forms;
using FunPro.CW2._9987.DAL;

namespace FunPro.CW2._9987
{
    public partial class ApplicantListForm : Form
    {
        public ApplicantListForm()
        {
            InitializeComponent();
        }

        private void ApplicantListForm_Load(object sender, EventArgs e)
        {
            // loading the parent form
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // loading the information of the appplicants
            LoadData();
        }

        // method to load the data of the applicants
        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new ApplicantList().GetAllApplicants();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // loading the ApplicantEditForm
            new ApplicantEditForm().CreateNewApplicant();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // checking if an applicant is selected
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant");
            else
            {
                // loading the ApplicantEditForm to update the selected applicant's information
                var applicant = (Applicants)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantEditForm().UpdateApplicant(applicant);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // checking if an applicant is selected
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant");
            else
            {
                // deleting the selected applicant according to their id
                var applicant = (Applicants)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantManager().Delete(applicant.Id);
                LoadData();
            }

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // checking if an attribute is selected to sort by
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                // sorting the applicants by their score                                
                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new ApplicantList().Sort();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // checking if the proper ID is passed
            if(nudApplicantId.Value <= 0)
            {
                MessageBox.Show("Provide a correct ID number;");
            }
            else
            {
                // setting selected applicant's id              
                var selectedId = Convert.ToInt32(nudApplicantId.Value);

                dgv.DataMember = "";
                dgv.DataSource = null;
                // searching according to id
                dgv.DataSource = new ApplicantList().Search(selectedId);
            }            
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                // if applicant is not selected, show the corresponding message
                MessageBox.Show("Please select an applicant");
            }                
            else if (new TestManager().GetAllTests().Count == 0)
            {
                // if no tests, show the message
                MessageBox.Show("There are no tests to take. Please add some tests first.");

                // showing all the tests
                MyForms.GetForm<TestListForm>().Show();
            }
            else
            {
                // loading the TestTake form according to the selected applicant
                var applicant = (Applicants)dgv.SelectedRows[0].DataBoundItem;                
                new TestTake().ShowTests(applicant.Name, applicant.Id, applicant.Score, applicant.TestTaken);                
            }
        }
    }
}
