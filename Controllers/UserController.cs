using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployee _employeeRepository;

        public UserController(IUserRepository userRepository, IEmployee employeeRepository)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("loginusername")]
        public async Task<IActionResult> GetLoginComputerName()
        {
            try
            {
                var nid = await _userRepository.GetLoginUsernameAsync();

                if (string.IsNullOrEmpty(nid))
                {
                    return Unauthorized();
                }

                var response = LoginUsernameResponse.FromNid(nid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("loginuseremployee")]
        public async Task<IActionResult> GetLoginUserAndEmployee()
        {
            try
            {
                // เรียก GetLoginComputerName
                var nid = await _userRepository.GetLoginUsernameAsync();

                if (string.IsNullOrEmpty(nid))
                {
                    return Unauthorized();
                }

                // เรียก GetEmployeeByNid โดยใช้ nid ที่ได้จาก GetLoginComputerName
                var employees = await _employeeRepository.GetEmployeeByNidAsync(nid);
                if (employees == null || employees.Count == 0)
                {
                    return NotFound();
                }

                // สร้าง response ที่รวมข้อมูลจากทั้งสอง API
                var response = new
                {
                    Nid = nid,
                    Employees = employees
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        [HttpGet("environmentusername")]
        public async Task<IActionResult> GetEnvironmentUsername()
        {
            try
            {
                var username = await _userRepository.GetEnvironmentUsernameAsync();

                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized();
                }

                var response = LoginUsernameResponse.FromNid(username);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}