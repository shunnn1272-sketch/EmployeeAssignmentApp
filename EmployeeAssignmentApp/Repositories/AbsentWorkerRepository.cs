using EmployeeAssignmentApp.Data;
using EmployeeAssignmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAssignmentApp.Repositories
{
    /// <summary>
    /// AbsentWorkerに対するデータアクセスを担当する
    /// </summary>
    public class AbsentWorkerRepository
    {
        private readonly AppDbContext _db;

        public AbsentWorkerRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(AbsentWorker absentWorker)
        {
            _db.AbsentWorkers.Add(absentWorker);
            _db.SaveChanges();
        }

        public List<AbsentWorker> GetAll()
        {
            return _db.AbsentWorkers
                .ToList();
        }

        public AbsentWorker? NameEmpty()
        {
            return _db.AbsentWorkers
                .Where(w=>w.AbsentWorkerName=="")
                .FirstOrDefault();
        }

        public AbsentWorker? GetByName(string absentWorkerName)
        {
            return _db.AbsentWorkers
                .FirstOrDefault(p => p.AbsentWorkerName == absentWorkerName);
        }

        public void Update(AbsentWorker absentWorker)
        {
            _db.AbsentWorkers.Update(absentWorker);
            _db.SaveChanges();
        }
    }
}
