using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using EmployeeModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRepository
{
    public interface IRepository
    {
        public bool CreateEmployee(EmployeeModels employee);
        public IEnumerable<EmployeeModels> GetEmployee(int id);
        public bool LoginValidation(string Email, string Password);
        public string DeleteEmployee(int id);
    }
}
