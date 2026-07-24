using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeAssignmentApp.Models;

namespace EmployeeAssignmentApp.Data
{
    /// <summary>
    /// DBとして使用するクラスと接続先の設定
    /// </summary>
    public  class AppDbContext:DbContext
    {
        public DbSet<Worker> Workers { get; set;}
        public DbSet<Process> Processes { get; set;}
        
        public DbSet<AbsentWorker> AbsentWorkers { get ; set;}

        /// <summary>
        /// データベースへの接続を設定
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EmployeeAssignmentApp.db");
        }
    }
}
