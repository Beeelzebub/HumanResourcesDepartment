using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int NumberOfWorkingDays { get; set; }
        public int NumberOfDaysActuallyWorked { get; set; }
        public int NumberOfDaysOff { get; set; }
        public string Period { get; set; }
        public Vacation Vacation { get; set; }
        public BusinessTrip BusinessTrip { get; set; }
        public SickLeave SickLeave { get; set; }
    }
}
