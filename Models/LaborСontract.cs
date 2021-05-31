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
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public float Salary { get; set; }
        public string Base { get; set; }


        public override string GetActionName() => "Заключение трудового договора";
        public override string GetDescription() => 
            "Название компании: " + CompanyName +
            "\nОтдел: " + Department.Name +
            "\nДолжность: " + Post.PostName +
            "\nОклад" + Salary + "бр." +
            "\nОснование" + Base +
            "\nДата составления: " + DateOfPreparation.ToShortDateString() + 
            "\nДата принятия: " + DateOfAdoption.ToShortDateString();
    }
}
