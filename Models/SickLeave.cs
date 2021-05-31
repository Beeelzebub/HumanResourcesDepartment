using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class SickLeave : Action
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public override Employee Employee { get; set; }
        public DateTime SickLeaveStartDate { get; set; }
        public DateTime SickLeaveEndDate { get; set; }
        public string SickLeaveReason { get; set; }

        public override string GetActionName() => "Больничный";
        public override string GetDescription() => 
            "Причина: " + SickLeaveReason +
            "\nДата начала: " + SickLeaveStartDate.ToShortDateString() +
            "\nДата окончания: " + SickLeaveEndDate.ToShortDateString();
    }
}
