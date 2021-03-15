namespace FunPro.CW2._9987
{
    partial class TestListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testQuestion1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testQuestion1AnswerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testQuestion2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testQuestion2AnswerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testQuestion3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testQuestion3AnswerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoGenerateColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.testNameDataGridViewTextBoxColumn,
            this.testQuestion1DataGridViewTextBoxColumn,
            this.testQuestion1AnswerDataGridViewTextBoxColumn,
            this.testQuestion2DataGridViewTextBoxColumn,
            this.testQuestion2AnswerDataGridViewTextBoxColumn,
            this.testQuestion3DataGridViewTextBoxColumn,
            this.testQuestion3AnswerDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.testsBindingSource;
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(843, 290);
            this.dgv.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testNameDataGridViewTextBoxColumn
            // 
            this.testNameDataGridViewTextBoxColumn.DataPropertyName = "TestName";
            this.testNameDataGridViewTextBoxColumn.HeaderText = "Test Name";
            this.testNameDataGridViewTextBoxColumn.Name = "testNameDataGridViewTextBoxColumn";
            this.testNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testQuestion1DataGridViewTextBoxColumn
            // 
            this.testQuestion1DataGridViewTextBoxColumn.DataPropertyName = "TestQuestion1";
            this.testQuestion1DataGridViewTextBoxColumn.HeaderText = "Question 1";
            this.testQuestion1DataGridViewTextBoxColumn.Name = "testQuestion1DataGridViewTextBoxColumn";
            this.testQuestion1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testQuestion1AnswerDataGridViewTextBoxColumn
            // 
            this.testQuestion1AnswerDataGridViewTextBoxColumn.DataPropertyName = "TestQuestion1Answer";
            this.testQuestion1AnswerDataGridViewTextBoxColumn.HeaderText = "Answer 1";
            this.testQuestion1AnswerDataGridViewTextBoxColumn.Name = "testQuestion1AnswerDataGridViewTextBoxColumn";
            this.testQuestion1AnswerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testQuestion2DataGridViewTextBoxColumn
            // 
            this.testQuestion2DataGridViewTextBoxColumn.DataPropertyName = "TestQuestion2";
            this.testQuestion2DataGridViewTextBoxColumn.HeaderText = "Question 2";
            this.testQuestion2DataGridViewTextBoxColumn.Name = "testQuestion2DataGridViewTextBoxColumn";
            this.testQuestion2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testQuestion2AnswerDataGridViewTextBoxColumn
            // 
            this.testQuestion2AnswerDataGridViewTextBoxColumn.DataPropertyName = "TestQuestion2Answer";
            this.testQuestion2AnswerDataGridViewTextBoxColumn.HeaderText = "Answer 2";
            this.testQuestion2AnswerDataGridViewTextBoxColumn.Name = "testQuestion2AnswerDataGridViewTextBoxColumn";
            this.testQuestion2AnswerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testQuestion3DataGridViewTextBoxColumn
            // 
            this.testQuestion3DataGridViewTextBoxColumn.DataPropertyName = "TestQuestion3";
            this.testQuestion3DataGridViewTextBoxColumn.HeaderText = "Question 3";
            this.testQuestion3DataGridViewTextBoxColumn.Name = "testQuestion3DataGridViewTextBoxColumn";
            this.testQuestion3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testQuestion3AnswerDataGridViewTextBoxColumn
            // 
            this.testQuestion3AnswerDataGridViewTextBoxColumn.DataPropertyName = "TestQuestion3Answer";
            this.testQuestion3AnswerDataGridViewTextBoxColumn.HeaderText = "Answer 3";
            this.testQuestion3AnswerDataGridViewTextBoxColumn.Name = "testQuestion3AnswerDataGridViewTextBoxColumn";
            this.testQuestion3AnswerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testsBindingSource
            // 
            this.testsBindingSource.DataSource = typeof(FunPro.CW2._9987.DAL.Tests);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnRefresh.Location = new System.Drawing.Point(581, 357);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 40);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnDelete.Location = new System.Drawing.Point(725, 357);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 40);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnEdit.Location = new System.Drawing.Point(725, 307);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 40);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnAdd.Location = new System.Drawing.Point(581, 307);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 40);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // TestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 409);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgv);
            this.Name = "TestListForm";
            this.Text = "Tests";
            this.Load += new System.EventHandler(this.TestListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testQuestion1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testQuestion1AnswerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testQuestion2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testQuestion2AnswerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testQuestion3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testQuestion3AnswerDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource testsBindingSource;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
    }
}