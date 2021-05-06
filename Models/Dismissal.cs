using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Dismissal
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime DateOfPreparation { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public string Reason { get; set; }
    }
}
