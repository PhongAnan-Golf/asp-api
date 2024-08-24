using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class EmployeeDto
    {

        public string NID { get; set; }

        public string First_LastName { get; set; }

        public string First_LastName2 { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public string Section { get; set; }

        public string Division { get; set; }

        public int Approval { get; set; }
    }
}