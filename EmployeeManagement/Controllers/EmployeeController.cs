using EmployeeModel.Models;
using EmployeeRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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
        [Route("api/loginEmployee")]
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
    }
}
