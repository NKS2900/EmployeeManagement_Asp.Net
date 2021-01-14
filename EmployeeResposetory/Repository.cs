using EmployeeModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeRepository
{
    public class Repository : IRepository
    {
        private readonly EmployeeContext employeeContext;
        public Repository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
        public string CreateEmployee(EmployeeModels employee)
        {
            employeeContext.EmployeeTable.Add(employee);
            employeeContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public string LoginValidation(string Email, string Password)
        {   
            var userData = this.employeeContext.EmployeeTable.Where(x => x.Email == Email && x.Password==Password).SingleOrDefault();
            EmployeeModels emp=this.employeeContext.EmployeeTable.Find(userData);
            if (emp == null)
            {
                return "Field";
            }
            string message = "LOGIN_SUCCESS";
            return message;
        }

        public IEnumerable<EmployeeModels> GetEmployee(string id)
        {
            List<EmployeeModels> employees = new List<EmployeeModels>();
            employees = employeeContext.EmployeeTable.ToList();
            return employees;
        }

        public string DeleteEmployee(string  id)
        {
            EmployeeModels employee = employeeContext.EmployeeTable.Find(id);
            if (employee == null)
            {
                return "Not Found.";
            }

            employeeContext.EmployeeTable.Remove(employee);
            employeeContext.SaveChanges();

            return "SUCCESS";
        }
    }
}
