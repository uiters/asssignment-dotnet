using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStoreLibrary
{
    public interface IEmployeeService
    {
        bool Login(string id, string pass);

        bool GetRole(string id);

        bool ChangePassword(string id, string newPass);

        bool ChangeRole(string id, bool newRole);

        Employee GetEmployee(string id);

    }

    public class EmployeeService : Provider, IEmployeeService
    {
        private readonly static string changePassQuery = "update Employee set EmpPassword = @EmpPassword where EmpID = @EmpID";
        private readonly static string changeRoleQuery = "update Employee set EmpRole = @EmpRole where EmpID = @EmpID";
        private readonly static string getEmployeeQuery = "select * from Employee where EmpID = @EmpID";
        public EmployeeService(DataProvider provider) : base(provider)
        {
        }

        public bool ChangePassword(string id, string newPass)
        {
           return DataProvider.ExecuteNoneQuery(changePassQuery, new object[] { newPass, id }) > 0;
        }

        public bool ChangeRole(string id, bool newRole)
        {
            return DataProvider.ExecuteNoneQuery(changeRoleQuery, new object[] { newRole, id }) > 0;
        }

        public Employee GetEmployee(string id)
        {
            DataTable data = DataProvider.ExecuteQuery(getEmployeeQuery, new object[] { id });
            return new Employee(data.Rows[0]);
        }

        public bool GetRole(string id)
        {
            Employee employee = GetEmployee(id);
            return employee.Role;
        }

        public bool Login(string id, string pass)
        {
            Employee employee = GetEmployee(id);
            return employee.Pass.Equals(pass);
        }
    }
}
