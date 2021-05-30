using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class LaborСontract : Action
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public override Employee Employee { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateOfPreparation { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public float Salary { get; set; }
        public string Base { get; set; }


        public override string GetActionName() => "Заключение трудового договора";
        public override string GetDescription() => "fsd";
    }
}
