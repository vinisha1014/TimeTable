namespace TimeTable2
{
    partial class PracticalAssign
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
            this.timeTableDataSet2 = new TimeTable2.TimeTableDataSet2();
            this.timeTableDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeTableDataSet3 = new TimeTable2.TimeTableDataSet3();
            this.pracAssignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pracAssignTableAdapter = new TimeTable2.TimeTableDataSet3TableAdapters.PracAssignTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pracDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracAssignBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            label1.Location = new System.Drawing.Point(390, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(500, 60);
            label1.TabIndex = 4;
            label1.Text = "Assign Practical Slot To Teachers";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.stdDataGridViewTextBoxColumn,
            this.pracDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.teacherDataGridViewTextBoxColumn,
            this.creditDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pracAssignBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1264, 540);
            this.dataGridView1.TabIndex = 5;
            // 
            // timeTableDataSet2
            // 
            this.timeTableDataSet2.DataSetName = "TimeTableDataSet2";
            this.timeTableDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timeTableDataSet2BindingSource
            // 
            this.timeTableDataSet2BindingSource.DataSource = this.timeTableDataSet2;
            this.timeTableDataSet2BindingSource.Position = 0;
            // 
            // timeTableDataSet3
            // 
            this.timeTableDataSet3.DataSetName = "TimeTableDataSet3";
            this.timeTableDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pracAssignBindingSource
            // 
            this.pracAssignBindingSource.DataMember = "PracAssign";
            this.pracAssignBindingSource.DataSource = this.timeTableDataSet3;
            // 
            // pracAssignTableAdapter
            // 
            this.pracAssignTableAdapter.ClearBeforeFill = true;
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
            // pracDataGridViewTextBoxColumn
            // 
            this.pracDataGridViewTextBoxColumn.DataPropertyName = "Prac";
            this.pracDataGridViewTextBoxColumn.HeaderText = "Prac";
            this.pracDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pracDataGridViewTextBoxColumn.Name = "pracDataGridViewTextBoxColumn";
            this.pracDataGridViewTextBoxColumn.Width = 150;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "Batch";
            this.batchDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.Width = 150;
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
            // PracticalAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 701);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(label1);
            this.Name = "PracticalAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PracticalAssign";
            this.Load += new System.EventHandler(this.PracticalAssign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracAssignBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource timeTableDataSet2BindingSource;
        private TimeTableDataSet2 timeTableDataSet2;
        private TimeTableDataSet3 timeTableDataSet3;
        private System.Windows.Forms.BindingSource pracAssignBindingSource;
        private TimeTableDataSet3TableAdapters.PracAssignTableAdapter pracAssignTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pracDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditDataGridViewTextBoxColumn;
    }
}