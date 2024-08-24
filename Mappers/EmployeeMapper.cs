using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMapper
    {
       public static EmployeeDto ToDtoFromEmployee(this Employee employee)
        {
            return new EmployeeDto
            {
                NID = employee.NID,
                First_LastName = employee.First_LastName,
                First_LastName2 = employee.First_LastName2,
                Department = employee.Department,
                Position = employee.Position,
                Email = employee.Email,
                Section = employee.Section,
                Division = employee.Division,
                Approval = employee.Approval
            };
        }
    }
}