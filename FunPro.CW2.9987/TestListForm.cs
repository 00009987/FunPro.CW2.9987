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
    public partial class TestListForm : Form
    {
        public TestListForm()
        {
            InitializeComponent();
        }

        private void TestListForm_Load(object sender, EventArgs e)
        {
            // loading the parent form
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // loading the tests
            LoadData();            
        }

        // method to load the data of the  tests
        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new TestList().GetAllTests();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // checking if a test is selected
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a test");
            else
            {
                // deleting the selected test according to its id
                var test = (Tests)dgv.SelectedRows[0].DataBoundItem;
                new TestManager().Delete(test.Id);
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // loading the TestEditForm
            new TestEditForm().CreateNewTest();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // checking if a test is selected
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a test");
            else
            {
                // loading the TestEditForm to update the selected test's information
                var test = (Tests)dgv.SelectedRows[0].DataBoundItem;                
                new TestEditForm().UpdateTest(test);
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
                ByAttribute selectedAttribute = ByAttribute.TestName;
                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TestList().Sort(selectedAttribute);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // checking if an attribute is selected to search by
            if (cbxSearch.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to search by");
            // checking if an empty string is passed
            else if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                MessageBox.Show("Provide the search term");
            else
            {
                // declearing an attribute var
                var selectedAttribute = new ByAttribute();                              

                // setting the attribute according to selected item
                if(cbxSearch.SelectedIndex == 0)
                {
                    selectedAttribute = ByAttribute.TestName;
                }else if (cbxSearch.SelectedIndex == 1)
                {
                    selectedAttribute = ByAttribute.Question1;
                }else if (cbxSearch.SelectedIndex == 2)
                {
                    selectedAttribute = ByAttribute.Question2;
                }
                else
                {
                    selectedAttribute = ByAttribute.Question3;
                }

                // searching according to the passed term and selected attribute
                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TestList().Search(tbxSearch.Text, selectedAttribute);
            }
        }
    }
}
