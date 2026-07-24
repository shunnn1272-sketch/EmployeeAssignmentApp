using EmployeeAssignmentApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EmployeeAssignmentApp.Models;

namespace EmployeeAssignmentApp.Forms
{
    /// <summary>
    /// 作業者を新規登録する画面
    /// </summary>
    public partial class AddWorkerForm : Form
    {
        private readonly WorkerRepository _wRepo;
        private int workerId;

        public AddWorkerForm(WorkerRepository wRepo)
        {
            InitializeComponent();
            _wRepo = wRepo;
        }

        private void AddWorkerForm_Load(object sender, EventArgs e)
        {
            var all = _wRepo.GetAll();
            var last = all.LastOrDefault();



            //int workerId;
            if (last == null)
            {
                workerId = 1;
            }
            else
            {
                workerId = last.WorkerId + 1;
            }

            
            txtWorkerCode.Text = "W" + workerId.ToString("D5");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWorkerName.Text))
            {
                MessageBox.Show("名前が入力されていません");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbPosition.Text))
            {
                MessageBox.Show("役職が入力されていません");
                return;
            }

            _wRepo.Add(new Worker(workerId, txtWorkerCode.Text, txtWorkerName.Text, cmbPosition.Text));

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            this.Close();
        }
    }
}
