using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class LaborСontract
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateOfPreparation { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public float Salary { get; set; }
        public string Base { get; set; }

    }
}
