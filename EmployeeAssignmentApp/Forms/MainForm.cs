using EmployeeAssignmentApp.Data;
using EmployeeAssignmentApp.Forms;
using EmployeeAssignmentApp.Models;
using EmployeeAssignmentApp.Repositories;
using EmployeeAssignmentApp.Services;

using System.Drawing.Text;


namespace EmployeeAssignmentApp
{
    public partial class MainForm : Form
    {
        private readonly ProcessRepository _pRepo;
        private readonly WorkerRepository _wRepo;
        private readonly AbsentWorkerRepository _aRepo;
        private readonly WorkerAssignmentService _service;

        //DataGridViewで選択されている行番号
        private int _selectedRow;

        //作業者一覧が工程への割当か不在者の割り当てかを判定する
        private bool _absentOrNot;

        /// <summary>
        /// 作業員割当と管理を行うメイン画面
        /// </summary>
        public MainForm(ProcessRepository pRepo, WorkerRepository wRepo, AbsentWorkerRepository aRepo,WorkerAssignmentService service)
        {
            InitializeComponent();

            _pRepo = pRepo;
            _wRepo = wRepo;
            _aRepo = aRepo;
            _service=service;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            SetupGridAbsent();
            ShowProcess();
            ShowAbsent();
        }

        /// <summary>
        /// 作業者配置用のDataGridViewの設定
        /// </summary>
        private void SetupGrid()
        {
            dgvAssign.AutoGenerateColumns = false;

            dgvAssign.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "工程",
                DataPropertyName = "ProcessName",
                Width = 300
            });

            DataGridViewButtonColumn workerColumn = new DataGridViewButtonColumn();
            workerColumn.Name = "choiceWorker";
            workerColumn.HeaderText = "作業者";
            workerColumn.Text = "選択";
            workerColumn.Width = 180;
            workerColumn.DataPropertyName = "AssignedWorkerName";

            dgvAssign.Columns.Add(workerColumn);
        }

        /// <summary>
        /// 不在者配置用のDataGridViewの設定
        /// </summary>
        private void SetupGridAbsent()
        {
            dgvAbsent.AutoGenerateColumns = false;


            DataGridViewButtonColumn absentColumn = new DataGridViewButtonColumn();
            absentColumn.Name = "AbsentWorkers";
            absentColumn.HeaderText = "名前";
            absentColumn.Width = 198;
            absentColumn.DataPropertyName = "AbsentWorkerName";

            dgvAbsent.Columns.Add(absentColumn);

        }

        /// <summary>
        /// DBから工程の情報を取得し、表示する
        /// </summary>
        private void ShowProcess()
        {
            var allProcesses = _pRepo.GetAll();

            dgvAssign.DataSource = null;
            dgvAssign.DataSource = allProcesses;
        }

        /// <summary>
        /// 不在者一覧の表示
        /// 初回起動時のみ不在者配置用の空行を作成
        /// </summary>
        private void ShowAbsent()
        {

            var absent = _aRepo.GetAll();
            if (absent.Count <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    _aRepo.Add(new());
                }

                absent = _aRepo.GetAll();
            }

            dgvAbsent.DataSource = null;
            dgvAbsent.DataSource = absent;
        }

        private void dgvAssign_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ヘッダー行がクリックされた場合は処理しない
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvAssign.Columns[e.ColumnIndex].Name == "choiceWorker")
            {
                _selectedRow = e.RowIndex;
                workerList.DataSource = null;

                Process process = (Process)dgvAssign.Rows[_selectedRow].DataBoundItem;

                //選択した工程に割当可能な作業員のみを表示
                var nameList=_service.AssignListUpdate(process!);
              
                workerList.DataSource = nameList;

                //作業員一覧でダブルクリック時、工程へ作業員を割り当てる処理をする
                _absentOrNot = false;
            }

        }

        private void dgvAbsent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvAbsent.Columns[e.ColumnIndex].Name == "AbsentWorkers")
            {
                _selectedRow = e.RowIndex;

                //不在者リストに割当可能な作業員を表示
                var nameList=_service.AbsentListUpdate();
                
                workerList.DataSource = null;
                workerList.DataSource = nameList;

                //作業員一覧でダブルクリック時、不在者リストへ作業員を割り当てる処理をする
                _absentOrNot = true;
            }
        }

        
        private void workerList_DoubleClick(object sender, EventArgs e)
        {
            if (_selectedRow < 0)
            {
                workerList.DataSource = null;
                return;
            }

            //_absentOrNotの状態によって工程への配置か不在者リストへの配置か切り替え
            //不在者リストへ作業員を配置する
            if (_absentOrNot)
            {
                var absent = (AbsentWorker)dgvAbsent.Rows[_selectedRow].DataBoundItem;
                if (workerList.SelectedItem is not string workerName)
                {
                    return;
                }

                absent.AbsentWorkerName = workerName;

                dgvAbsent.Rows[_selectedRow]
                   .Cells["AbsentWorkers"]
                   .Value = absent.AbsentWorkerName;

                _aRepo.Update(absent);
                dgvAbsent.Refresh();
                workerList.DataSource = null;
            }

            //工程へ作業者を配置する
            if (!_absentOrNot)
            {
                Process process = (Process)dgvAssign.Rows[_selectedRow].DataBoundItem;
                if (workerList.SelectedItem is not string workerName)
                {
                    return;
                }

                process.AssignedWorkerName = workerName;

                dgvAssign.Rows[_selectedRow]
                    .Cells["choiceWorker"]
                    .Value = process.AssignedWorkerName;

                _pRepo.Update(process);
                dgvAssign.Refresh();
                workerList.DataSource = null;
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {

            var allProcess = _pRepo.GetAll();

            var assignedList = _service.Assign();

            
            //作業員が割当できない場合、空リストを受け取る
            if(assignedList.Count <= 0)
            {
                MessageBox.Show("割当てできません");

                //割当できない場合、既存の割当もクリアする
                foreach (var process in allProcess)
                {
                    process.AssignedWorkerName = "";
                }
                dgvAssign.Refresh();
                workerList.DataSource = null;
                return;
            }
            else
            {
                for (int i = 0; i < allProcess.Count; i++)
                {
                    Process process = (Process)dgvAssign.Rows[i].DataBoundItem;


                    //既に手動で割り当てられている工程は割当を維持
                    if (process.AssignedWorkerName != "")
                    {
                        continue;
                    }

                    //自動割当結果から名前が一致する工程への作業員の割当を取得
                    var searchProcess = assignedList
                        .Where(w => w.ProcessName == process.ProcessName)
                        .First();

                    dgvAssign.Rows[i]
                        .Cells["choiceWorker"]
                        .Value = searchProcess.AssignedWorkerName;

                    _pRepo.Update(searchProcess);
                    
                    
                }
                dgvAssign.Refresh();
                workerList.DataSource = null;
            }
        }


        private void dgvAssign_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Process process = (Process)dgvAssign.Rows[_selectedRow].DataBoundItem;
            process.AssignedWorkerName = "";
            _pRepo.Update(process);
            dgvAssign.Refresh();
        }


        private void dgvAbsent_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var absent = (AbsentWorker)dgvAbsent.Rows[_selectedRow].DataBoundItem;
            absent.AbsentWorkerName = "";
            dgvAbsent.Refresh();
            _aRepo.Update(absent);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var allProcess = _pRepo.GetAll();
            foreach (var process in allProcess)
            {
                process.AssignedWorkerName = "";
                _pRepo.Update(process);
            }
            dgvAssign.Refresh();
        }

        private void btnAbsentClear_Click(object sender, EventArgs e)
        {
            var allAbsent = _aRepo.GetAll();
            foreach (var absent in allAbsent)
            {
                absent.AbsentWorkerName = "";
                _aRepo.Update(absent);
            }
            dgvAbsent.Refresh();
        }

        

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new AddProcessForm(_pRepo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowProcess();

            }
        }

        private void 削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new DeleteProcessForm(_pRepo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowProcess();

            }
        }

        private void 追加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using var form = new AddWorkerForm(_wRepo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowProcess();


            }

        }

        private void 削除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using var form = new DeleteWorkerForm(_wRepo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowProcess();

            }
        }

        private void 編集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new WorkerUpdateForm(_wRepo, _pRepo);

            if (form.ShowDialog() == DialogResult.OK)
            {

                ShowProcess();
            }

        }

        private void 一覧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new GetAllWorkerForm(_wRepo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ShowProcess();


            }
        }

        
    }
}
