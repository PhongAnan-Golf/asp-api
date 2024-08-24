using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;

        public EmployeesController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("{nid}")]
        public async Task<IActionResult> GetEmployeeByNid(string nid)
        {
            var employees = await _employeeRepository.GetEmployeeByNidAsync(nid);
            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }
    }
}