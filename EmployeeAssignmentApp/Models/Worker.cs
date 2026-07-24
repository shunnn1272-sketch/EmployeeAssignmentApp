using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAssignmentApp.Models
{
    /// <summary>
    /// 作業員の情報を表す
    /// </summary>
    public class Worker
    {
        public int WorkerId { get; set;}

        public string WorkerCode { get; set;}
        public string WorkerName { get; set;}
        public string Position { get; set;}

        /// <summary>
        /// 作業可能な工程の一覧
        /// </summary>
        public List<Process> EnableProcess { get; set; } = new();

        public Worker(int workerId, string workerCode,string workerName, string position)
        {
            WorkerId=workerId;
            WorkerCode=workerCode;
            WorkerName=workerName;
            Position=position;
        }
    }

    
        
}
