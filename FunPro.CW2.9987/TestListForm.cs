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
    }
}
