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
    /// 作業者を選択し、作業可能工程の一覧を見る、追加、削除する画面
    /// </summary>
    public partial class WorkerUpdateForm : Form
    {
        private readonly WorkerRepository _wRepo;
        private readonly ProcessRepository _pRepo;
        

        public WorkerUpdateForm(WorkerRepository wRepo, ProcessRepository pRepo)
        {
            InitializeComponent();
            _wRepo = wRepo;
            _pRepo = pRepo;
            
        }

        private void WorkerUpdateForm_Load(object sender, EventArgs e)
        {
            SetupView();
        }

        //習得済み工程表示用ListViewの設定
        private void SetupView()
        {
            lvEnableProcess.Columns.Add("作業可能工程",999 ); 
        }

        //ListViewへ選択した作業員の作業可能工程を表示
        private void ShowEnableProcess()
        {
            var worker = _wRepo.Search(txtCode.Text, txtName.Text);

            List<Process> enableProcess = worker.EnableProcess;
            lvEnableProcess.Items.Clear();

            foreach (var e in enableProcess)
            {
                lvEnableProcess.Items.Add(e.ProcessName);
            }

        }


        private void btnDecide_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || _wRepo.GetByCode(txtCode.Text) == null)
            {
                MessageBox.Show("正しい社員コードを入力してください");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名前を入力してください");
                return;
            }

            var updateWorker = _wRepo.Search(txtCode.Text, txtName.Text);
            if (updateWorker == null)
            {
                MessageBox.Show("存在しません");
                return;
            }

            ShowEnableProcess();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || _wRepo.GetByCode(txtCode.Text) == null)
            {
                MessageBox.Show("正しい社員コードを入力してください");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名前を入力してください");
                return;
            }

            var worker = _wRepo.Search(txtCode.Text, txtName.Text);
            if (worker == null)
            {
                MessageBox.Show("存在しません");
                return;
            }

            //子フォームに選択した作業者の情報を渡す
            using var form = new AddEnableProcessForm(_pRepo, _wRepo, worker);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowEnableProcess();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) || _wRepo.GetByCode(txtCode.Text) == null)
            {
                MessageBox.Show("正しい社員コードを入力してください");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("名前を入力してください");
                return;
            }

            var worker = _wRepo.Search(txtCode.Text, txtName.Text);
            if (worker == null)
            {
                MessageBox.Show("存在しません");
                return;
            }

            //子フォームに選択した作業者の情報を渡す
            using var form = new DeleteEnableProcessForm(_pRepo,_wRepo, worker);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowEnableProcess();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
