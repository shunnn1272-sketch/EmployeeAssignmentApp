using EmployeeAssignmentApp.Data;
using EmployeeAssignmentApp.Repositories;
using EmployeeAssignmentApp.Services;

namespace EmployeeAssignmentApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var db = new AppDbContext();
            var pRepo=new ProcessRepository(db);
            var wRepo=new WorkerRepository(db,pRepo);
            var aRepo=new AbsentWorkerRepository(db);
            var service=new WorkerAssignmentService(wRepo,pRepo,aRepo);
            Application.Run(new MainForm(pRepo,wRepo,aRepo,service));

            
        }
    }
}