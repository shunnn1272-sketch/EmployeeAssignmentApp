namespace EmployeeAssignmentApp.Forms
{
    partial class WorkerUpdateForm
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
            txtCode = new TextBox();
            txtName = new TextBox();
            btnDecide = new Button();
            btnOk = new Button();
            label1 = new Label();
            label2 = new Label();
            lvEnableProcess = new ListView();
            btnAdd = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Location = new Point(122, 88);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(125, 27);
            txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(64, 150);
            txtName.Name = "txtName";
            txtName.Size = new Size(183, 27);
            txtName.TabIndex = 1;
            // 
            // btnDecide
            // 
            btnDecide.Location = new Point(140, 201);
            btnDecide.Name = "btnDecide";
            btnDecide.Size = new Size(107, 29);
            btnDecide.TabIndex = 2;
            btnDecide.Text = "習得済み一覧";
            btnDecide.UseVisualStyleBackColor = true;
            btnDecide.Click += btnDecide_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(670, 397);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 3;
            btnOk.Text = "閉じる";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(177, 65);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 6;
            label1.Text = "社員コード";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 127);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 7;
            label2.Text = "名前";
            // 
            // lvEnableProcess
            // 
            lvEnableProcess.FullRowSelect = true;
            lvEnableProcess.GridLines = true;
            lvEnableProcess.Location = new Point(283, 69);
            lvEnableProcess.Name = "lvEnableProcess";
            lvEnableProcess.Size = new Size(342, 306);
            lvEnableProcess.TabIndex = 8;
            lvEnableProcess.UseCompatibleStateImageBehavior = false;
            lvEnableProcess.View = View.Details;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(509, 34);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(52, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "追加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(567, 34);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(58, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // WorkerUpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lvEnableProcess);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOk);
            Controls.Add(btnDecide);
            Controls.Add(txtName);
            Controls.Add(txtCode);
            Name = "WorkerUpdateForm";
            Text = "作業者情報編集";
            Load += WorkerUpdateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCode;
        private TextBox txtName;
        private Button btnDecide;
        private Button btnOk;
        private Label label1;
        private Label label2;
        private ListView lvEnableProcess;
        private Button btnAdd;
        private Button btnDelete;
    }
}