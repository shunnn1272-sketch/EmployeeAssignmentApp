namespace EmployeeAssignmentApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dateTimePicker1 = new DateTimePicker();
            btnAuto = new Button();
            btnClear = new Button();
            menuStrip1 = new MenuStrip();
            工程ToolStripMenuItem = new ToolStripMenuItem();
            追加ToolStripMenuItem = new ToolStripMenuItem();
            削除ToolStripMenuItem = new ToolStripMenuItem();
            作業員ToolStripMenuItem = new ToolStripMenuItem();
            追加ToolStripMenuItem1 = new ToolStripMenuItem();
            削除ToolStripMenuItem1 = new ToolStripMenuItem();
            編集ToolStripMenuItem = new ToolStripMenuItem();
            一覧ToolStripMenuItem = new ToolStripMenuItem();
            lblOut = new Label();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            dgvAssign = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            workerList = new ListBox();
            dgvAbsent = new DataGridView();
            btnAbsentClear = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssign).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAbsent).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(45, 46);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // btnAuto
            // 
            btnAuto.Location = new Point(342, 114);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(94, 29);
            btnAuto.TabIndex = 1;
            btnAuto.Text = "自動配置";
            btnAuto.UseVisualStyleBackColor = true;
            btnAuto.Click += btnAuto_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(442, 114);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "クリア";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = SystemColors.ScrollBar;
            menuStrip1.BackgroundImageLayout = ImageLayout.None;
            menuStrip1.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 128);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 工程ToolStripMenuItem, 作業員ToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.Flow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(839, 33);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // 工程ToolStripMenuItem
            // 
            工程ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 追加ToolStripMenuItem, 削除ToolStripMenuItem });
            工程ToolStripMenuItem.Name = "工程ToolStripMenuItem";
            工程ToolStripMenuItem.ShortcutKeyDisplayString = "P";
            工程ToolStripMenuItem.Size = new Size(58, 27);
            工程ToolStripMenuItem.Text = "工程";
            // 
            // 追加ToolStripMenuItem
            // 
            追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            追加ToolStripMenuItem.Size = new Size(128, 28);
            追加ToolStripMenuItem.Text = "追加";
            追加ToolStripMenuItem.Click += 追加ToolStripMenuItem_Click;
            // 
            // 削除ToolStripMenuItem
            // 
            削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            削除ToolStripMenuItem.Size = new Size(128, 28);
            削除ToolStripMenuItem.Text = "削除";
            削除ToolStripMenuItem.Click += 削除ToolStripMenuItem_Click;
            // 
            // 作業員ToolStripMenuItem
            // 
            作業員ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 追加ToolStripMenuItem1, 削除ToolStripMenuItem1, 編集ToolStripMenuItem, 一覧ToolStripMenuItem });
            作業員ToolStripMenuItem.Name = "作業員ToolStripMenuItem";
            作業員ToolStripMenuItem.Size = new Size(75, 27);
            作業員ToolStripMenuItem.Text = "作業員";
            // 
            // 追加ToolStripMenuItem1
            // 
            追加ToolStripMenuItem1.Name = "追加ToolStripMenuItem1";
            追加ToolStripMenuItem1.Size = new Size(128, 28);
            追加ToolStripMenuItem1.Text = "追加";
            追加ToolStripMenuItem1.Click += 追加ToolStripMenuItem1_Click;
            // 
            // 削除ToolStripMenuItem1
            // 
            削除ToolStripMenuItem1.Name = "削除ToolStripMenuItem1";
            削除ToolStripMenuItem1.Size = new Size(128, 28);
            削除ToolStripMenuItem1.Text = "削除";
            削除ToolStripMenuItem1.Click += 削除ToolStripMenuItem1_Click;
            // 
            // 編集ToolStripMenuItem
            // 
            編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            編集ToolStripMenuItem.Size = new Size(128, 28);
            編集ToolStripMenuItem.Text = "編集";
            編集ToolStripMenuItem.Click += 編集ToolStripMenuItem_Click;
            // 
            // 一覧ToolStripMenuItem
            // 
            一覧ToolStripMenuItem.Name = "一覧ToolStripMenuItem";
            一覧ToolStripMenuItem.Size = new Size(128, 28);
            一覧ToolStripMenuItem.Text = "一覧";
            一覧ToolStripMenuItem.Click += 一覧ToolStripMenuItem_Click;
            // 
            // lblOut
            // 
            lblOut.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblOut.Location = new Point(551, 396);
            lblOut.Name = "lblOut";
            lblOut.Size = new Size(86, 28);
            lblOut.TabIndex = 14;
            lblOut.Text = "不在";
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // dgvAssign
            // 
            dgvAssign.AllowUserToAddRows = false;
            dgvAssign.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssign.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssign.Location = new Point(12, 149);
            dgvAssign.Name = "dgvAssign";
            dgvAssign.ReadOnly = true;
            dgvAssign.RowHeadersWidth = 51;
            dgvAssign.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssign.Size = new Size(533, 524);
            dgvAssign.TabIndex = 15;
            dgvAssign.CellContentClick += dgvAssign_CellContentClick;
            dgvAssign.CellContentDoubleClick += dgvAssign_CellContentDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(551, 118);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 18;
            label2.Text = "作業員";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(12, 118);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 19;
            label3.Text = "配置";
            // 
            // workerList
            // 
            workerList.FormattingEnabled = true;
            workerList.Location = new Point(551, 149);
            workerList.Name = "workerList";
            workerList.SelectionMode = SelectionMode.MultiExtended;
            workerList.Size = new Size(273, 244);
            workerList.TabIndex = 20;
            workerList.DoubleClick += workerList_DoubleClick;
            // 
            // dgvAbsent
            // 
            dgvAbsent.AllowUserToDeleteRows = false;
            dgvAbsent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAbsent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAbsent.Location = new Point(551, 428);
            dgvAbsent.Name = "dgvAbsent";
            dgvAbsent.ReadOnly = true;
            dgvAbsent.RowHeadersWidth = 51;
            dgvAbsent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAbsent.Size = new Size(273, 245);
            dgvAbsent.TabIndex = 23;
            dgvAbsent.CellContentClick += dgvAbsent_CellContentClick;
            dgvAbsent.CellContentDoubleClick += dgvAbsent_CellContentDoubleClick;
            // 
            // btnAbsentClear
            // 
            btnAbsentClear.Location = new Point(730, 396);
            btnAbsentClear.Name = "btnAbsentClear";
            btnAbsentClear.Size = new Size(94, 29);
            btnAbsentClear.TabIndex = 24;
            btnAbsentClear.Text = "クリア";
            btnAbsentClear.UseVisualStyleBackColor = true;
            btnAbsentClear.Click += btnAbsentClear_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 682);
            Controls.Add(btnAbsentClear);
            Controls.Add(dgvAbsent);
            Controls.Add(workerList);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvAssign);
            Controls.Add(lblOut);
            Controls.Add(btnClear);
            Controls.Add(btnAuto);
            Controls.Add(dateTimePicker1);
            Controls.Add(menuStrip1);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "作業員配置";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssign).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAbsent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button btnAuto;
        private Button btnClear;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 工程ToolStripMenuItem;
        private ToolStripMenuItem 追加ToolStripMenuItem;
        private ToolStripMenuItem 削除ToolStripMenuItem;
        private ToolStripMenuItem 作業員ToolStripMenuItem;
        private ToolStripMenuItem 追加ToolStripMenuItem1;
        private ToolStripMenuItem 削除ToolStripMenuItem1;
        private ToolStripMenuItem 編集ToolStripMenuItem;
        private Label lblOut;
        private ToolStripMenuItem 一覧ToolStripMenuItem;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private DataGridView dgvAssign;
        private Label label2;
        private Label label3;
        private ListBox workerList;
        private DataGridView dgvAbsent;
        private Button btnAbsentClear;
    }
}
