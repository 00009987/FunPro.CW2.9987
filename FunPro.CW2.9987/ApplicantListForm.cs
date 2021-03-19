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
    public partial class ApplicantListForm : Form
    {
        public ApplicantListForm()
        {
            InitializeComponent();
        }

        private void ApplicantListForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new ApplicantList().GetAllApplicants();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ApplicantEditForm().CreateNewApplicant();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant");
            else
            {
                var applicant = (Applicants)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantEditForm().UpdateApplicant(applicant);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant");
            else
            {
                var applicant = (Applicants)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantManager().Delete(applicant.Id);
                LoadData();
            }

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                ByAttribute selectedAttribute;
                selectedAttribute = ByAttribute.Score;
                
                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new ApplicantList().Sort(selectedAttribute);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(nudApplicantId.Value <= 0)
            {
                MessageBox.Show("Provide a correct ID number;");
            }
            else
            {
                var selectedAttribute = ByAttribute.Id;
                var selectedId = Convert.ToInt32(nudApplicantId.Value);

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new ApplicantList().Search(selectedId, selectedAttribute);
            }            
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                // if applicant is not selected, show corresponging message
                MessageBox.Show("Please select an applicant");
            }                
            else if (new TestManager().GetAllTests().Count == 0)
            {
                // if no tests, show message
                MessageBox.Show("There are no tests to take. Please add some tests first.");

                // showing all the tests
                MyForms.GetForm<TestListForm>().Show();
            }
            else
            {
                var applicant = (Applicants)dgv.SelectedRows[0].DataBoundItem;                
                new TestTake().ShowTests(applicant.Name, applicant.Id, applicant.Score, applicant.TestTaken);                
            }
        }
    }
}
