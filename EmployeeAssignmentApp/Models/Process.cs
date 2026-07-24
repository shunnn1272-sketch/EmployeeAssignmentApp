using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAssignmentApp.Models
{
    /// <summary>
    /// 工程情報を表す
    /// データベースのProcessesに対応する
    /// </summary>
    public class Process
    {
        
        public int ProcessId { get; set;}
        public string ProcessName { get; set;}

        //割り当てられた作業員名
        public string AssignedWorkerName { get; set;}="";
        /// <summary>
        /// この工程を担当可能な作業員一覧
        /// </summary>
        public List<Worker> EnableWorker { get; set; } = new();

        public Process(int processId,string processName)
        {
            ProcessId=processId;
            ProcessName=processName;
        }
    }
}
