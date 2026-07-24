using EmployeeAssignmentApp.Models;
using EmployeeAssignmentApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace EmployeeAssignmentApp.Services
{
    /// <summary>
    /// 作業員、工程を整理してデータを渡す
    /// </summary>
    public class WorkerAssignmentService
    {
        private readonly WorkerRepository _wRepo;
        private readonly ProcessRepository _pRepo;
        private readonly AbsentWorkerRepository _aRepo;
        

        public WorkerAssignmentService(WorkerRepository wRepo,ProcessRepository pRepo,AbsentWorkerRepository aRepo)
        {
           
            _wRepo=wRepo;
            _pRepo=pRepo;
            _aRepo=aRepo;
        }

        /// <summary>
        /// 工程への作業員自動割当ロジックを担当
        /// 不在者、割当済み、作業可能かを考慮して割り当てる
        /// </summary>
        /// <returns>自動割当の結果。
        /// すべての工程に割り当てられない場合は空リスト</returns>
        public List<Process> Assign()
        {

            int loopCount=0;

            //割当済み工程を保存
            List<Process> assignedProcess=new();

            //割当済み作業者を保存
            List<Worker> assignedWorker = new();

            Random random = new Random();
            var allProcess = _pRepo.GetAll();
            var allWorker=_wRepo.GetAll();

            //割当済み工程リスト
            var processAssigned = allProcess
                .Where(p => p.AssignedWorkerName != "")
                .ToList();

            //割当済み作業者名リスト
            List<Worker> workerAssigned = new();
            var workerName = processAssigned
                .Select(p => p.AssignedWorkerName)
                .ToList();

            foreach (var worker in workerName)
            {
                var name = _wRepo.GetByName(worker);
                if (name != null)
                {
                    //取得した作業員を割当済み作業員リストに追加
                    workerAssigned.Add(name);
                }
            }

            //不在者リスト
            var allAbsent = _aRepo.GetAll();
            var absentWorker = allAbsent
                .Where(a => a.AbsentWorkerName != "")
                .Select(a => a.AbsentWorkerName)
                .ToList();

            foreach (var worker in absentWorker)
            {
                var name = _wRepo.GetByName(worker);
                if (name != null)
                {
                    //取得した不在者を割当済み作業員リストに追加
                    workerAssigned.Add(name);
                }
            }



            while (true)
            {
                //作業者未割当の工程をリスト化
                //whileループで配置済みの工程を除外
                //既に手動で配置されていた工程を除外
                var remainingProcess =allProcess
                    .Except(assignedProcess)
                    .Except(processAssigned)
                    .ToList();

                //未割当の工程が０になったらループ終了
                if(remainingProcess.Count==0) 
                {
                    break;
                }

                //工程の作業可能者リストから既に割り当てられている作業者を除外
                //新しいProcessとしてリストに保存
                List<Process> processes=new();
                foreach(var p in remainingProcess)
                {
                    var process = new Process(p.ProcessId,p.ProcessName);

                    process.EnableWorker=p.EnableWorker
                        .Except(assignedWorker)//whileループで配置済みの作業者を除外
                        .Except(workerAssigned)//既に手動で配置されていた作業者を除外
                        .ToList();

                    processes.Add(process);
                }

                //割当可能者が少ない工程を順に並べる
                //一番割当可能者が少ない工程を選択する
                var choiceProcess=processes
                    .OrderBy(p=>p.EnableWorker.Count)
                    .First();

                //その工程の割当可能者を作業可能工程数が少ない順に並べる
                var enableWorker=choiceProcess.EnableWorker
                    .OrderBy(p=>p.EnableProcess.Count)
                    .ToList();

                //工程の作業可能者が0の場合、自動で割り当てた作業者と工程をすべてクリア
                //100回以上組み合わせを繰り返す。
                //すべての工程に作業者が割り当てられない場合は、割当不可としてループ終了
                if(enableWorker.Count == 0)
                {
                    foreach(var process in remainingProcess)
                    {
                        process.AssignedWorkerName="";
                        
                    }
                    assignedWorker.Clear();
                    assignedProcess.Clear();

                    loopCount++;
                    if(loopCount>=100)
                    {
                        break;//割当不可
                    }
                    
                }
                else
                {
                    var enableProcessCount = enableWorker[0].EnableProcess.Count;

                    //作業可能工程数が同じ者をリスト化
                    //その中からランダムで作業者を選ぶ
                    var sameEnableProcessWorker = enableWorker
                        .Where(w => w.EnableProcess.Count == enableProcessCount)
                        .ToList();

                    var worker = sameEnableProcessWorker[random.Next(sameEnableProcessWorker.Count)];

                    //工程を取得しなおす
                    var process=allProcess
                        .First(p=>p.ProcessName==choiceProcess.ProcessName);

                    process.AssignedWorkerName = worker.WorkerName;
                    assignedProcess.Add(process);//割当済みに工程を追加
                    assignedWorker.Add(worker);//割当済みに作業者を追加
                }
            }

            return assignedProcess;

        }
        

        /// <summary>
        /// 指定した工程への割当可能作業者をリスト化
        /// </summary>
        /// <param name="process">DataGridViewで選択した工程</param>
        /// <returns>指定した工程に割当可能な作業者リスト
        /// いない場合は空リスト</returns>
        public List<string> AssignListUpdate(Process process)
        {
            //選択した工程を作業可能者を含めて取得しなおす
            //作業可能者の名前をリスト化
            var processName = process.ProcessName;
            var processIncludeWorker = _pRepo.GetByName(processName);
            var enableWorker = processIncludeWorker.EnableWorker
                .ToList();
            var enableWorkerName = enableWorker
                .Select(w => w.WorkerName)
                .ToList();

            //工程に割り当てられている作業者の名前をリスト化
            var allProcess = _pRepo.GetAll();
            var extractName = allProcess
                .Select(p => p.AssignedWorkerName)
                .ToList();

            //不在者の名前をリスト化
            var absentWorkers = _aRepo.GetAll();
            var absentWorkerName = absentWorkers
                .Where(w => w.AbsentWorkerName != "")
                .Select(w => w.AbsentWorkerName)
                .ToList();

            //作業可能者リストから割当済みと不在者の名前を除外
            var nameList = enableWorkerName
                .Except(extractName)
                .Except(absentWorkerName)
                .ToList();

            return nameList;
        }

        /// <summary>
        /// 不在に割当可能な作業者をリスト化
        /// </summary>
        /// <returns>不在に割り当て可能な作業者リスト
        /// いない場合は空リスト</returns>
        public List<string> AbsentListUpdate()
        {
            //全作業者の名前をリスト化
            var allWorker = _wRepo.GetAll();
            var allWorkerName = allWorker
                .Select(w => w.WorkerName)
                .ToList();

            //不在者の名前をリスト化
            var absentWorkers = _aRepo.GetAll();
            var absentWorkerName = absentWorkers
                .Where(w => w.AbsentWorkerName != "")
                .Select(w => w.AbsentWorkerName)
                .ToList();
            
            //割当済み作業者の名前をリスト化
            var allProcess = _pRepo.GetAll();
            var assignedWorkers = allProcess
                .Where(p => p.AssignedWorkerName != "")
                .Select(p => p.AssignedWorkerName)
                .ToList();

            //全作業者から不在者と割当済み作業者を除外してリスト化
            var nameList = allWorkerName
                .Except(absentWorkerName)
                .Except(assignedWorkers)
                .ToList();

            return nameList;
        }
        
    }
}
