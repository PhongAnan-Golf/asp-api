using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Employee
    {
        public string EmpCode { get; set; }

        public string NikonID { get; set; }

        public string NID { get; set; }

        public string NameEn { get; set; }

        public string LastnameEn { get; set; }

        public string NameEn_LastnameEn_Capital { get; set; }

        public string First_LastName { get; set; }

        public string First_LastName2 { get; set; }

        public string Name_LastNameTH { get; set; }

        public string Department { get; set; }

        public string CostCenter { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public string Section { get; set; } // nvarchar(max)

        public DateTime Createdate { get; set; }

        public string Division { get; set; }

        public int Approval { get; set; }
    }
}