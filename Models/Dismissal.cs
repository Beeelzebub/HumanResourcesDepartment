using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Dismissal : Action
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public override Employee Employee { get; set; }
        public DateTime DateOfPreparation { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public string Reason { get; set; }


        public override string GetActionName() => "Увольнение";
        public override string GetDescription() => "fsd";
    }
}
