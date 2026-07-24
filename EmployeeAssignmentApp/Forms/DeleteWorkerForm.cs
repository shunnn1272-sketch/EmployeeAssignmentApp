using EmployeeAssignmentApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeAssignmentApp.Forms
{
    /// <summary>
    /// 既存の作業員から指定した作業員を削除する画面
    /// </summary>
    public partial class DeleteWorkerForm : Form
    {
        private readonly WorkerRepository _wRepo;
        public DeleteWorkerForm(WorkerRepository wRepo)
        {
            InitializeComponent();
            _wRepo = wRepo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || _wRepo.GetByCode(txtCode.Text) == null)
            {
                MessageBox.Show("正しいコードを入力してください");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名前を入力してください");
                return;
            }

            var deleteWorker = _wRepo.Search(txtCode.Text, txtName.Text);
            if (deleteWorker == null)
            {
                MessageBox.Show("存在しません");
                return;
            }
            _wRepo.Delete(deleteWorker);
            

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
