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
    public class EmployeeRepository : DapperBase
    {
        private AdventureWorks2014Entities db = new AdventureWorks2014Entities();

        public static List<Employee> GetAllEmployees()
        {

            Employee em = new Employee();
            List<Employee> EmployeeUserList = new List<Employee>();
            string sql = @"SELECT * 
  FROM [AdventureWorks2014].[HumanResources].[Employee]";
            using (var con = Open(DBHelper.ConnectionString))
            {
                CommandDefinition command = new CommandDefinition(sql, commandType: CommandType.Text);
                EmployeeUserList = con.Query<Employee>(command).ToList();
            }
            return EmployeeUserList;
        }

        
    }
}