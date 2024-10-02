namespace TimeTable2
{
    partial class SubjectDetails
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
            this.subjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectsTableAdapter = new TimeTable2.TimeTableDataSet1TableAdapters.SubjectsTableAdapter();
            this.stdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stdDataGridViewTextBoxColumn,
            this.subjectDataGridViewTextBoxColumn,
            this.creditsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.subjectsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(79, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(868, 505);
            this.dataGridView1.TabIndex = 0;
            // 
            // timeTableDataSet1
            // 
            this.timeTableDataSet1.DataSetName = "TimeTableDataSet1";
            this.timeTableDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // subjectsBindingSource
            // 
            this.subjectsBindingSource.DataMember = "Subjects";
            this.subjectsBindingSource.DataSource = this.timeTableDataSet1;
            // 
            // subjectsTableAdapter
            // 
            this.subjectsTableAdapter.ClearBeforeFill = true;
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
            // creditsDataGridViewTextBoxColumn
            // 
            this.creditsDataGridViewTextBoxColumn.DataPropertyName = "Credits";
            this.creditsDataGridViewTextBoxColumn.HeaderText = "Credits";
            this.creditsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.creditsDataGridViewTextBoxColumn.Name = "creditsDataGridViewTextBoxColumn";
            this.creditsDataGridViewTextBoxColumn.Width = 150;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            label1.Location = new System.Drawing.Point(364, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(394, 60);
            label1.TabIndex = 4;
            label1.Text = "Subject Details";
            // 
            // SubjectDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 628);
            this.Controls.Add(label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SubjectDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubjectDetails";
            this.Load += new System.EventHandler(this.SubjectDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private TimeTableDataSet1 timeTableDataSet1;
        private System.Windows.Forms.BindingSource subjectsBindingSource;
        private TimeTableDataSet1TableAdapters.SubjectsTableAdapter subjectsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditsDataGridViewTextBoxColumn;
    }
}