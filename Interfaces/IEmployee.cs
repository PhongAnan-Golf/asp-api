using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;

namespace api.Interfaces
{
    public interface IEmployee
    {
         Task<List<EmployeeDto>> GetEmployeeByNidAsync(string nid);
    }
}