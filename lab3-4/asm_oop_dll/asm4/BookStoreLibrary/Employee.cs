using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStoreLibrary
{
    public class Employee
    {
        private string id;
        private string pass;
        private bool role;

        public Employee(string id, string pass, bool role)
        {
            this.Id = id;
            this.Pass = pass;
            this.Role = role;
        }

        public Employee(DataRow row)
        {
            id = Convert.ToString(row["EmpID"]);
            pass = Convert.ToString(row["EmpPassword"]);
            role = Convert.ToBoolean(row["EmpRole"]);
        }

        public string Id { get => id.Trim().ToLower(); set => id = value; }
        public string Pass { get => pass.Trim(); set => pass = value; }
        public bool Role { get => role; set => role = value; }

        public bool IsNotCorrect()
        {
            return string.IsNullOrWhiteSpace(id) || string.IsNullOrEmpty(pass);
        }
    }
}
