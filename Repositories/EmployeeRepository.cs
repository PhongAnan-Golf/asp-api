using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Mappers;
using Microsoft.EntityFrameworkCore;
using api.DTOs;

namespace api.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context=context;
        }
        async Task<List<EmployeeDto>> IEmployee.GetEmployeeByNidAsync(string nid)
        {
            var employees = await _context.Employees.Where(e=>e.NID==nid).ToListAsync();

            return employees.Select(e => e.ToDtoFromEmployee()).ToList();
        }
    }
}