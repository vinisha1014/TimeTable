namespace TimeTable2
{
    partial class PracticalDetails
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
            this.timeTableDataSet4 = new TimeTable2.TimeTableDataSet4();
            this.practicalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.practicalTableAdapter = new TimeTable2.TimeTableDataSet4TableAdapters.PracticalTableAdapter();
            this.stdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pSubjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.practicalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            label1.Location = new System.Drawing.Point(391, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(394, 60);
            label1.TabIndex = 4;
            label1.Text = "Practical Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stdDataGridViewTextBoxColumn,
            this.pSubjectDataGridViewTextBoxColumn,
            this.creditDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.practicalBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(39, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1050, 478);
            this.dataGridView1.TabIndex = 5;
            // 
            // timeTableDataSet4
            // 
            this.timeTableDataSet4.DataSetName = "TimeTableDataSet4";
            this.timeTableDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // practicalBindingSource
            // 
            this.practicalBindingSource.DataMember = "Practical";
            this.practicalBindingSource.DataSource = this.timeTableDataSet4;
            // 
            // practicalTableAdapter
            // 
            this.practicalTableAdapter.ClearBeforeFill = true;
            // 
            // stdDataGridViewTextBoxColumn
            // 
            this.stdDataGridViewTextBoxColumn.DataPropertyName = "Std";
            this.stdDataGridViewTextBoxColumn.HeaderText = "Std";
            this.stdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.stdDataGridViewTextBoxColumn.Name = "stdDataGridViewTextBoxColumn";
            this.stdDataGridViewTextBoxColumn.Width = 150;
            // 
            // pSubjectDataGridViewTextBoxColumn
            // 
            this.pSubjectDataGridViewTextBoxColumn.DataPropertyName = "PSubject";
            this.pSubjectDataGridViewTextBoxColumn.HeaderText = "PSubject";
            this.pSubjectDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pSubjectDataGridViewTextBoxColumn.Name = "pSubjectDataGridViewTextBoxColumn";
            this.pSubjectDataGridViewTextBoxColumn.Width = 150;
            // 
            // creditDataGridViewTextBoxColumn
            // 
            this.creditDataGridViewTextBoxColumn.DataPropertyName = "Credit";
            this.creditDataGridViewTextBoxColumn.HeaderText = "Credit";
            this.creditDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.creditDataGridViewTextBoxColumn.Name = "creditDataGridViewTextBoxColumn";
            this.creditDataGridViewTextBoxColumn.Width = 150;
            // 
            // PracticalDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 627);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(label1);
            this.Name = "PracticalDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PracticalDetails";
            this.Load += new System.EventHandler(this.PracticalDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTableDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.practicalBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private TimeTableDataSet4 timeTableDataSet4;
        private System.Windows.Forms.BindingSource practicalBindingSource;
        private TimeTableDataSet4TableAdapters.PracticalTableAdapter practicalTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSubjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditDataGridViewTextBoxColumn;
    }
}