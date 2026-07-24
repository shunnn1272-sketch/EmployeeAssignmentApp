using EmployeeAssignmentApp.Models;
using EmployeeAssignmentApp.Repositories;
using EmployeeAssignmentApp.Services;
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
    /// 選択した作業者の作業可能工程を削除する画面
    /// </summary>
    public partial class DeleteEnableProcessForm : Form
    {
        private readonly ProcessRepository _pRepo;
        private readonly WorkerRepository _wRepo;
        
        //前画面で選択した作業者を取得するため
        private readonly Worker _worker;
        public DeleteEnableProcessForm(ProcessRepository pRepo, WorkerRepository wRepo, Worker worker)
        {
            InitializeComponent();
            _pRepo = pRepo;
            _wRepo=wRepo;
            _worker = worker;
        }

        private void DeleteEnableProcessForm_Load(object sender, EventArgs e)
        {
            AddItems();
        }

        //作業者の作業可能工程を表示
        private void AddItems()
        {
            var enableProcess = _worker.EnableProcess;

            foreach (var e in enableProcess)
            {
                cmbProcess.Items.Add(e.ProcessName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbProcess.Text))
            {
                MessageBox.Show("工程名が入力されていません");
                return;
            }

            if (_pRepo.GetByName(cmbProcess.Text) == null)
            {
                MessageBox.Show("工程名を正しく入力してください");
                return;
            }

            //選択した作業者の作業可能工程から選択した工程を削除
            //選択した工程の作業可能者から選択した作業者を削除
            _wRepo.DeleteEnableWorker(cmbProcess.Text,_worker.WorkerCode);
            

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
