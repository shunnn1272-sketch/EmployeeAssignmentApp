using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAssignmentApp.Models
{
    /// <summary>
    /// 不在者を表す
    /// データベースのAbsentWorkersに対応する
    /// </summary>
    public class AbsentWorker
    {
        public int Id { get; set;}
        public string AbsentWorkerName { get; set;}="";
    }
}
