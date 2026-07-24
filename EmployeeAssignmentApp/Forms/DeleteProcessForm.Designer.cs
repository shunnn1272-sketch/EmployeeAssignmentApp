namespace EmployeeAssignmentApp.Forms
{
    partial class DeleteProcessForm
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
            btnDelete = new Button();
            btnCancel = new Button();
            cmbProcessName = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(368, 239);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(490, 239);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbProcessName
            // 
            cmbProcessName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProcessName.FormattingEnabled = true;
            cmbProcessName.Location = new Point(163, 120);
            cmbProcessName.Name = "cmbProcessName";
            cmbProcessName.Size = new Size(315, 28);
            cmbProcessName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 123);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 5;
            label2.Text = "工程名";
            // 
            // DeleteProcessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 289);
            Controls.Add(label2);
            Controls.Add(cmbProcessName);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Name = "DeleteProcessForm";
            Text = "工程削除";
            Load += DeleteProcessForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Button btnCancel;
        private ComboBox cmbProcessName;
        private Label label2;
    }
}