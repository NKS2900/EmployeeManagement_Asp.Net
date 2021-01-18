using EmployeeModel.Models;
using EmployeeRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace EmployeeManagement.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        
        private readonly IRepository repository;
        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("api/addEmployee")]
        public IActionResult AddEmployee([FromBody]EmployeeModels employee)
        {
            bool result = repository.CreateEmployee(employee);
            if (result)
            {
                return this.Ok(new { success = true, Message = "Record added successfully", Data = result });
            }
            else
            { 
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/loginEmployee/{Email}/{Password}/")]
        public IActionResult LoginEmployee(string Email, string Password)
        {
            bool result = this.repository.LoginValidation(Email, Password);
            if (result)
            {
                return this.Ok(new { success = true, Message = "Login successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/get")]
        public IActionResult GetEmployees(int id)
        {
            try 
            {
                IEnumerable<EmployeeModels> list = this.repository.GetEmployee(id);
                return this.Ok(list);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/delete/{id}/")]
        public IActionResult DeletePersonalDetails([FromRoute]int id)
        {
            var result = this.repository.DeleteEmployee(id);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/getById/{id}/")]
        public IActionResult GetEmployeeByIds(int id)
        {
            try
            {
                IEnumerable<EmployeeModels> list = this.repository.GetEmployeeById(id);
                return this.Ok(list);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("api/update")]
        public IActionResult UpdateEmployee(EmployeeModels employee)
        {
            var result = this.repository.UpdateEmployee(employee);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Record Updated successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPut]
        [Route("api/reset/{oldpass}/{newpass}/")]
        public IActionResult ResetPasswords([FromRoute] string oldpass, string newpass)
        {
            var result = this.repository.ResetPassword(oldpass, newpass);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Password Updated successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }


        [HttpGet]
        [Route("api/sendEmail/{emailAddress}/")]
        public IActionResult ResetPasswords([FromRoute] string emailAddress)
        {
            var result = this.repository.SendEmail(emailAddress);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Password Updated successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}