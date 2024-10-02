namespace TimeTable2
{
    partial class SubjectAssign
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
            System.Windows.Forms.Label label1;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timeTableDataSet1 = new TimeTable2.TimeTableDataSet1();
            this.timeTableDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeTableDataSet2 = new TimeTable2.TimeTableDataSet2();
            this.subjectAssignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectAssignTableAdapter = new TimeTable2.TimeTableDataSet2TableAdapters.SubjectAssignTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAssignBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.stdDataGridViewTextBoxColumn,
            this.subjectDataGridViewTextBoxColumn,
            this.teacherDataGridViewTextBoxColumn,
            this.creditDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.subjectAssignBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(29, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(838, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // timeTableDataSet1
            // 
            this.timeTableDataSet1.DataSetName = "TimeTableDataSet1";
            this.timeTableDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timeTableDataSet1BindingSource
            // 
            this.timeTableDataSet1BindingSource.DataSource = this.timeTableDataSet1;
            this.timeTableDataSet1BindingSource.Position = 0;
            // 
            // timeTableDataSet2
            // 
            this.timeTableDataSet2.DataSetName = "TimeTableDataSet2";
            this.timeTableDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // subjectAssignBindingSource
            // 
            this.subjectAssignBindingSource.DataMember = "SubjectAssign";
            this.subjectAssignBindingSource.DataSource = this.timeTableDataSet2;
            // 
            // subjectAssignTableAdapter
            // 
            this.subjectAssignTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // stdDataGridViewTextBoxColumn
            // 
            this.stdDataGridViewTextBoxColumn.DataPropertyName = "Std";
            this.stdDataGridViewTextBoxColumn.HeaderText = "Std";
            this.stdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.stdDataGridViewTextBoxColumn.Name = "stdDataGridViewTextBoxColumn";
            this.stdDataGridViewTextBoxColumn.Width = 150;
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            this.subjectDataGridViewTextBoxColumn.DataPropertyName = "Subject";
            this.subjectDataGridViewTextBoxColumn.HeaderText = "Subject";
            this.subjectDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            this.subjectDataGridViewTextBoxColumn.Width = 150;
            // 
            // teacherDataGridViewTextBoxColumn
            // 
            this.teacherDataGridViewTextBoxColumn.DataPropertyName = "Teacher";
            this.teacherDataGridViewTextBoxColumn.HeaderText = "Teacher";
            this.teacherDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.teacherDataGridViewTextBoxColumn.Name = "teacherDataGridViewTextBoxColumn";
            this.teacherDataGridViewTextBoxColumn.Width = 150;
            // 
            // creditDataGridViewTextBoxColumn
            // 
            this.creditDataGridViewTextBoxColumn.DataPropertyName = "Credit";
            this.creditDataGridViewTextBoxColumn.HeaderText = "Credit";
            this.creditDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.creditDataGridViewTextBoxColumn.Name = "creditDataGridViewTextBoxColumn";
            this.creditDataGridViewTextBoxColumn.Width = 150;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            label1.Location = new System.Drawing.Point(167, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(700, 79);
            label1.TabIndex = 4;
            label1.Text = "Assign Subject To Teacher";
            // 
            // SubjectAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 631);
            this.Controls.Add(label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SubjectAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubjectAssign";
            this.Load += new System.EventHandler(this.SubjectAssign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectAssignBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource timeTableDataSet1BindingSource;
        private TimeTableDataSet1 timeTableDataSet1;
        private TimeTableDataSet2 timeTableDataSet2;
        private System.Windows.Forms.BindingSource subjectAssignBindingSource;
        private TimeTableDataSet2TableAdapters.SubjectAssignTableAdapter subjectAssignTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditDataGridViewTextBoxColumn;
    }
}