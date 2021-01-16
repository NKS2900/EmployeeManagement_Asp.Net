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
        public bool CreateEmployee(EmployeeModels employee)
        {
            employeeContext.EmployeeTable.Add(employee);
            var emp=employeeContext.SaveChanges();
            if (emp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginValidation(string Email, string Password)
        {
            var userData = this.employeeContext.EmployeeTable.Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
            EmployeeModels emp=this.employeeContext.EmployeeTable.Find(userData);
            if (userData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<EmployeeModels> GetEmployee(int id)
        {
            List<EmployeeModels> employees = new List<EmployeeModels>();
            employees = employeeContext.EmployeeTable.ToList();
            return employees;
        }

        public string DeleteEmployee(int id)
        {
            try
            {
                var login = this.employeeContext.EmployeeTable.Find(id);
                this.employeeContext.EmployeeTable.Remove(login);
                this.employeeContext.SaveChangesAsync();
                return "SUCCESS";
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        //public IEnumerable<EmployeeModels> GetEmployeeById(int id)
        //{
        //    EmployeeModels emp = new EmployeeModels();
        //    emp.Id = id;
            
           
        //}
    }
}
