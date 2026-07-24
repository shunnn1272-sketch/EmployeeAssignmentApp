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
    /// 登録した作業員一覧を表示する画面
    /// </summary>
    public partial class GetAllWorkerForm : Form
    {
        private readonly WorkerRepository _wRepo;
        public GetAllWorkerForm(WorkerRepository wRepo)
        {
            InitializeComponent();
            _wRepo=wRepo;
        }

        private void GetAllWorkerForm_Load(object sender, EventArgs e)
        {
            SetupDgv();
            var worker= _wRepo.GetAll();

            dgvGetAll.DataSource=null;
            dgvGetAll.DataSource=worker;
        }

        //作業員を表示するDataGridViewの設定
        private void SetupDgv()
        {
            dgvGetAll.AutoGenerateColumns = false;
            dgvGetAll.ReadOnly = true;
            dgvGetAll.AllowUserToAddRows = false;
            dgvGetAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvGetAll.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText="社員コード",
                DataPropertyName="WorkerCode",
                Width=150
                
            });

            dgvGetAll.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText="名前",
                DataPropertyName="WorkerName",
                Width=150
            });

            dgvGetAll.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "役職",
                DataPropertyName = "Position",
                Width = 150
            });
        }

    }
}
