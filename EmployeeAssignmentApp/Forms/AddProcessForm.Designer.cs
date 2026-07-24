namespace EmployeeAssignmentApp.Forms
{
    partial class AddProcessForm
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
            txtProcessName = new TextBox();
            label1 = new Label();
            btn_Add = new Button();
            btn_Cancel = new Button();
            SuspendLayout();
            // 
            // txtProcessName
            // 
            txtProcessName.Location = new Point(97, 107);
            txtProcessName.Name = "txtProcessName";
            txtProcessName.Size = new Size(411, 27);
            txtProcessName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 107);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "工程名";
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(355, 233);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(94, 29);
            btn_Add.TabIndex = 2;
            btn_Add.Text = "追加";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(493, 233);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 29);
            btn_Cancel.TabIndex = 3;
            btn_Cancel.Text = "キャンセル";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // AddProcessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 289);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Add);
            Controls.Add(label1);
            Controls.Add(txtProcessName);
            Name = "AddProcessForm";
            Text = "工程追加";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProcessName;
        private Label label1;
        private Button btn_Add;
        private Button btn_Cancel;
    }
}