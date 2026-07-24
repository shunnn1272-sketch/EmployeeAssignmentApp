namespace EmployeeAssignmentApp.Forms
{
    partial class GetAllWorkerForm
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
            dgvGetAll = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvGetAll).BeginInit();
            SuspendLayout();
            // 
            // dgvGetAll
            // 
            dgvGetAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGetAll.Dock = DockStyle.Fill;
            dgvGetAll.Location = new Point(0, 0);
            dgvGetAll.Name = "dgvGetAll";
            dgvGetAll.RowHeadersWidth = 51;
            dgvGetAll.Size = new Size(478, 533);
            dgvGetAll.TabIndex = 0;
            // 
            // GetAllWorkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 533);
            Controls.Add(dgvGetAll);
            Name = "GetAllWorkerForm";
            Text = "社員一覧";
            Load += GetAllWorkerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGetAll).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGetAll;
    }
}