using EmployeeAssignmentApp.Data;
using EmployeeAssignmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Text;

namespace EmployeeAssignmentApp.Repositories
{
    /// <summary>
    /// Processに対するデータアクセスを担当する
    /// </summary>
    public class ProcessRepository
    {
        private readonly AppDbContext _db;
        
        public ProcessRepository(AppDbContext db)
        {
            _db=db;
            
        }

        public List<Process> GetAll()
        {
            return _db.Processes
                .Include(p=>p.EnableWorker)//担当可能な作業員も読み込み
                .OrderBy(p => p.ProcessId)
                .ToList();
        }

        public void Add(Process process)
        {
            _db.Processes.Add(process);
            _db.SaveChanges();
        }

        

        public void Delete(Process process)
        {
            _db.Processes.Remove(process);
            _db.SaveChanges();
        }


        public Process? GetByName(string processName)
        { 
            return _db.Processes
                .Include(p=>p.EnableWorker)//担当可能な作業員も読み込み
                .FirstOrDefault(p=>p.ProcessName==processName);
        }

        public void Update(Process process)
        {
            _db.Processes.Update(process);
            _db.SaveChanges();
        }
       
       

    }
}
