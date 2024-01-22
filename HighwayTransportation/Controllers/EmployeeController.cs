using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Microsoft.AspNetCore.Mvc;
using HighwayTransportation.Providers;
using Microsoft.OpenApi.Any;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeProvider _employeeProvider;

        public EmployeeController(EmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<GetEmployeeListDto>>> GetEmployees()
        {
            var employees = await _employeeProvider.GetEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDto employee)
        {
            var createdEmployee = await _employeeProvider.CreateEmployee(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDetailDto>> GetEmployee(int id)
        {
            var employee = await _employeeProvider.GetEmployeeDetail(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto employee)
        {
            var employeeEntity = await _employeeProvider.UpdateEmployee(id, employee);
            return Ok(employeeEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeProvider.DeleteEmployee(id);
            return Ok();
        }
    }
}
