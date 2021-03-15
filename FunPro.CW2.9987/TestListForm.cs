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
            dgv.DataSource = new TestList().GetAllTests();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a test");
            else
            {
                var test = (Tests)dgv.SelectedRows[0].DataBoundItem;
                new TestManager().Delete(test.Id);
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new TestEditForm().CreateNewTest();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a test");
            else
            {
                var test = (Tests)dgv.SelectedRows[0].DataBoundItem;                
                new TestEditForm().UpdateTest(test);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                ByAttribute selectedAttribute;
                selectedAttribute = ByAttribute.TestName;

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TestList().Sort(selectedAttribute);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearch.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to search by");
            else if (string.IsNullOrWhiteSpace(tbxSearch.Text))
                MessageBox.Show("Provide the search term");
            else
            {
                var selectedAttribute = new ByAttribute();                              

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

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TestList().Search(tbxSearch.Text, selectedAttribute);
            }
        }
    }
}
