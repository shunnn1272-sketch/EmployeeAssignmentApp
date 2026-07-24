namespace EmployeeAssignmentApp.Forms
{
    partial class AddWorkerForm
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
            txtWorkerName = new TextBox();
            cmbPosition = new ComboBox();
            txtWorkerCode = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtWorkerName
            // 
            txtWorkerName.Location = new Point(76, 82);
            txtWorkerName.Name = "txtWorkerName";
            txtWorkerName.Size = new Size(203, 27);
            txtWorkerName.TabIndex = 0;
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Items.AddRange(new object[] { "課長", "係長", "正社員", "契約社員" });
            cmbPosition.Location = new Point(355, 82);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(151, 28);
            cmbPosition.TabIndex = 1;
            // 
            // txtWorkerCode
            // 
            txtWorkerCode.Location = new Point(76, 161);
            txtWorkerCode.Name = "txtWorkerCode";
            txtWorkerCode.ReadOnly = true;
            txtWorkerCode.Size = new Size(125, 27);
            txtWorkerCode.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(376, 237);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "追加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(494, 237);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 59);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 5;
            label1.Text = "名前";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 138);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 6;
            label2.Text = "社員コード";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(355, 59);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 7;
            label3.Text = "役職";
            // 
            // AddWorkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 289);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(txtWorkerCode);
            Controls.Add(cmbPosition);
            Controls.Add(txtWorkerName);
            Name = "AddWorkerForm";
            Text = "作業者追加";
            Load += AddWorkerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWorkerName;
        private ComboBox cmbPosition;
        private TextBox txtWorkerCode;
        private Button btnAdd;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}