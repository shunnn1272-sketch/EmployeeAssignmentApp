using EmployeeAssignmentApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeAssignmentApp.Forms
{
    /// <summary>
    /// 既存の工程から選択した工程を削除する画面
    /// </summary>
    public partial class DeleteProcessForm : Form
    {
        private readonly ProcessRepository _pRepo;
        public DeleteProcessForm(ProcessRepository pRepo)
        {
            InitializeComponent();
            _pRepo = pRepo;
        }

        private void DeleteProcessForm_Load(object sender, EventArgs e)
        {
            AddItems();
        }

        private void AddItems()
        {
            var all = _pRepo.GetAll();

            foreach (var item in all)
            {
                cmbProcessName.Items.Add(item.ProcessName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(cmbProcessName.Text))
            {
                MessageBox.Show("正しい工程名を入力してください");
                return;
            }

            var deleteProcess = _pRepo.GetByName(cmbProcessName.Text);
            if (deleteProcess == null)
            {
                MessageBox.Show("工程が存在しません");
                return;
            }
            _pRepo.Delete(deleteProcess);
           

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}
