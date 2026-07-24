using EmployeeAssignmentApp.Data;
using EmployeeAssignmentApp.Models;
using EmployeeAssignmentApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmployeeAssignmentApp.Forms
{
    /// <summary>
    /// 工程を新規登録する画面
    /// </summary>
    public partial class AddProcessForm : Form
    {
        
        private readonly ProcessRepository _pRepo;
        public AddProcessForm(ProcessRepository pRepo)
        {
            InitializeComponent();
      
            _pRepo=pRepo;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProcessName.Text))
            {
                MessageBox.Show("工程名が入力されていません");
                return;
            }

            var exists = _pRepo.GetByName(txtProcessName.Text);

            if (exists!=null)
            {
                MessageBox.Show("既に登録されています");
                return;
            }

            var all = _pRepo.GetAll();
            var last = all.LastOrDefault();

            int processId;
            if (last == null)
            {
                processId = 1;
            }
            else
            {
                processId = last.ProcessId + 1;
            }


            _pRepo.Add(new Process(processId, txtProcessName.Text));
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            this.Close();
        }
    }
}
