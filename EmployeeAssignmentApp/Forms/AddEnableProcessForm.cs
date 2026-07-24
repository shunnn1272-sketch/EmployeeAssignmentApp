using EmployeeAssignmentApp.Repositories;
using EmployeeAssignmentApp.Services;
using EmployeeAssignmentApp.Models;
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
    /// 選択した作業者への作業可能工程の追加をする画面
    /// </summary>
    public partial class AddEnableProcessForm : Form
    {
        private readonly ProcessRepository _pRepo;
        private readonly WorkerRepository _wRepo;

        //前画面から作業者の情報を受け取るため
        private readonly Worker _worker;

        public AddEnableProcessForm(ProcessRepository pRepo,WorkerRepository wRepo,Worker worker)
        {
            InitializeComponent();
            _pRepo = pRepo;
            _wRepo=wRepo;
            _worker = worker;

        }

        private void AddEnableProcess_Load(object sender, EventArgs e)
        {
            AddItems();
        }

        /// <summary>
        /// 工程名の選択肢に未習得工程名を追加
        /// </summary>
        private void AddItems()
        {
            var allProcess = _pRepo.GetAll();
            var enableProcess = _worker.EnableProcess;



            var addEnableProcess = allProcess.Except(enableProcess).ToList();

            foreach (var e in addEnableProcess)
            {
                cmbProcess.Items.Add(e.ProcessName);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbProcess.Text))
            {
                MessageBox.Show("工程名が入力されていません");
                return;
            }

            if(_pRepo.GetByName(cmbProcess.Text)==null)
            {
                MessageBox.Show("工程名を正しく入力してください");
                return;
            }

            //選択した作業者の作業可能工程に選択した工程を追加
            //選択した工程の作業可能者に選択した作業者を追加
            _wRepo.AddEnableWorker(cmbProcess.Text,_worker.WorkerCode);

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
