using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DataAccess.Employees
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(); 
        Employee GetDetailsByID(int id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        void Save();
        void Dispose();
    }
}
