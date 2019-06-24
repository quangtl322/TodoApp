using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Models.Employees;
using TodoApp.Services;
namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.ListEmployeeAsync();
            // return Ok(new {message="hello"});
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid? id)
        {
            var responseModel = await _employeeService.GetByIdAsync(id);
            if (responseModel.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(responseModel.Data);
            }
            else
            {
                return BadRequest(new { Message = responseModel.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeManageModel employeeManageModel)
        {
            var responseModel = await _employeeService.AddEmployee(employeeManageModel);
            if (responseModel.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(responseModel.Data);
            }
            else
            {
                return BadRequest(new { Message = responseModel.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeManageModel employeeManageModel)
        {
            var responseModel = await _employeeService.UpdateEmployee(id, employeeManageModel);

            if (responseModel.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound("User is not found. Please try again!");
            }
            else
            {
                if (responseModel.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok(responseModel.Data);
                }
                else
                {
                    return BadRequest(new { Message = responseModel.Message });
                }
            }
        }
        [HttpPut("{id}/setdeleterecord")]
        public async Task<IActionResult> SetRecordDeleteEmployee(Guid id)
        {
            var responseModel = await _employeeService.SetRecordDeleteEmployee(id);
            if (responseModel.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound("User is not found. Please try again!");
            }
            else
            {
                if (responseModel.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok(responseModel.Data);
                }
                else
                {
                    return BadRequest(new { Message = responseModel.Message });
                }
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var responseModel = await _employeeService.DeleteEmployee(id);
            if (responseModel.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new { Message = responseModel.Message });
            }
        }
    }
}