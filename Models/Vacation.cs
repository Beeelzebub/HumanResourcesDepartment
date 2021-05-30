using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Vacation : Action
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public override Employee Employee { get; set; }
        public DateTime DateOfPreparation { get; set; }
        public DateTime VacationStartDate { get; set; }
        public DateTime VacationEndDate { get; set; }

        public override string GetActionName() => "Отпуск";
        public override string GetDescription() => "fsd";

    }
}
