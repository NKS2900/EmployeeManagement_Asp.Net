using EmployeeModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var emp = employeeContext.SaveChanges();
            if (emp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginValidation(string email, string password)
        {
            var userData = employeeContext.EmployeeTable.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            //EmployeeModels emp = employeeContext.EmployeeTable.Find(userData);

            if (userData.Email !=null && userData.Password != null)
            {
                return true;
            }
            else
            {
                return false;
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

        public IEnumerable<EmployeeModels> GetEmployeeById(int id)
        {
            List<EmployeeModels> employ = new List<EmployeeModels>();
            employ.Add(employeeContext.EmployeeTable.Find(id));
            return employ;
        }

        public string UpdateEmployee(EmployeeModels employeeModel)
        {
            try
            {
                this.employeeContext.EmployeeTable.Update(employeeModel);
                this.employeeContext.SaveChangesAsync();
                return "SUCCESS";
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public string ResetPassword(string oldpass, string newpass)
        {
            var dbEntry = employeeContext.EmployeeTable.FirstOrDefault(acc => acc.Password == oldpass);
            if (dbEntry != null)
            {
                dbEntry.Password = newpass;
                employeeContext.Entry(dbEntry).State = EntityState.Modified;
                employeeContext.SaveChanges();
                return "SUCCESS";
            }
            else
            {
                return "NOT_FOUND";
            }
        }

        public string SendEmail(string emailAddress)
        {
            string body;
            string subject="EmployeeManagement Credential" ;
            var dbEntry = employeeContext.EmployeeTable.FirstOrDefault(e => e.Email == emailAddress);
            if (dbEntry != null)
            {
                body = dbEntry.Password;                      
            }
            else
            {
                return "NOT_FOUND";
            }

            using (MailMessage mailMessage = new MailMessage("nijamsayyad95@gmail.com", emailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("nijamsayyad95@gmail.com", "nijam@13495");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "SUCCESS";
            }
        }
    }
}
