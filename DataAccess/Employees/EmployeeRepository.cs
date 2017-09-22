using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;



namespace DataAccess.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AdventureWorks2014Entities db = new AdventureWorks2014Entities();
        public EmployeeRepository(AdventureWorks2014Entities adventureWorks2014Entities)
        {
            this.db = adventureWorks2014Entities;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetDetailsByID(int id)
        {
            return db.Employees.Find(id);
        }

        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }





}
