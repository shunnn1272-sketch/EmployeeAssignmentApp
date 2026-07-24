using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using EmployeeAssignmentApp.Data;
using EmployeeAssignmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAssignmentApp.Repositories
{
    /// <summary>
    /// Workerに対するデータアクセスを担当する
    /// </summary>
    public class WorkerRepository
    {
        private readonly AppDbContext _db;
        private readonly ProcessRepository _pRepo;
        public WorkerRepository(AppDbContext db,ProcessRepository pRepo)
        {
            _db=db;
            _pRepo=pRepo;
        }
        public List<Worker> GetAll()
        {
            return _db.Workers
                .Include(w=>w.EnableProcess)//作業可能工程も取得
                .OrderBy(w=>w.WorkerCode)
                .ToList();
        }

        public Worker? GetByCode(string workerCode)
        {
           
            return _db.Workers
                .Include(w=>w.EnableProcess)//作業可能工程も取得
                .FirstOrDefault(w=>w.WorkerCode==workerCode);
        }

        public Worker? GetByName(string workerName)
        {

            return _db.Workers
                .Include(w => w.EnableProcess)//作業可能工程も取得
                .FirstOrDefault(w => w.WorkerName == workerName);
        }

        public Worker? Search(string workerCode,string workerName)
        {
           
            return _db.Workers
                .Include(w=>w.EnableProcess)//作業可能工程も取得
                .FirstOrDefault(w => w.WorkerCode == workerCode && w.WorkerName == workerName);
        }

        public void Add(Worker worker)
        {
            _db.Workers.Add(worker);
            _db.SaveChanges();
        }

        

        public void Delete(Worker worker)
        {
             _db.Workers.Remove(worker);
            _db.SaveChanges();

        }

        public void Update(Worker worker)
        {
            _db.Workers.Update(worker);
            _db.SaveChanges();
        }
        
        /// <summary>
        /// 工程への作業可能者の追加
        /// 同時に作業者への作業可能工程の追加
        /// </summary>
        /// <param name="process">取得する工程の名前</param>
        /// <param name="workerCode">取得する作業者の名前</param>
        public void AddEnableWorker(string process, string workerCode)
        {
            var editProcess = _pRepo.GetByName(process);
            var editWorker=GetByCode(workerCode);

            editProcess.EnableWorker.Add(editWorker);
            
            _db.SaveChanges();
        }

        /// <summary>
        /// 工程から作業可能者の削除
        /// 同時に作業者から作業可能工程の削除
        /// </summary>
        /// <param name="process">取得する工程の名前</param>
        /// <param name="workerCode">取得する作業者の名前</param>
        public void DeleteEnableWorker(string process, string workerCode)
        {
            var editProcess = _pRepo.GetByName(process);
            var editWorker = GetByCode(workerCode);

            editProcess.EnableWorker.Remove(editWorker);
            
            _db.SaveChanges();
        }
        
    }
}
