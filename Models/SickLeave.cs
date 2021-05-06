using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class SickLeave
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime SickLeaveStartDate { get; set; }
        public DateTime SickLeaveEndDate { get; set; }
        public string SickLeaveReason { get; set; }
    }
}
