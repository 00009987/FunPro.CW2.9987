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
    public partial class ApplicantEditForm : Form
    {
        public ApplicantEditForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Applicants Applicant { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewApplicant()
        {
            Mode = FormMode.CreateNew;
            Applicant = new Applicants();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

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

        private void ShowApplicantInControls()
        {
            tbxName.Text = Applicant.Name;
            nudScore.Value = Applicant.Score;
            tbxTestTaken.Text = Applicant.TestTaken;
        }

        private void GrabUserInput()
        {
            Applicant.Name = tbxName.Text;
            Applicant.Score = Convert.ToInt32(nudScore.Value);
            Applicant.TestTaken = tbxTestTaken.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new ApplicantManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Applicant);
                else
                    manager.Update(Applicant);

                MyForms.GetForm<ApplicantListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ApplicantEditForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
        }
    }
}
