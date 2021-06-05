using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class LaborСontract : Action
    {
        //[NotMapped]
        //public Employee Employee { get; set; }
        public string CompanyName { get; set; }
        public DateTime? DateOfPreparation { get; set; }
        public DateTime? DateOfAdoption { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public float Salary { get; set; }
        public string Base { get; set; }

        public override string GetActionName() => "Заключение трудового договора";
        public override string GetDescription() =>
            "<strong>Название компании: </strong>" + CompanyName +
            "<br /><strong>Отдел: </strong>" + Department.Name +
            "<br /><strong>Должность: </strong>" + Post.PostName +
            "<br /><strong>Оклад: </strong>" + Salary + "бр." +
            "<br /><strong>Основание: </strong>" + Base +
            "<br /><strong>Дата составления: </strong>" + DateOfPreparation?.ToShortDateString() +
            "<br /><strong>Дата принятия: </strong>" + DateOfAdoption?.ToShortDateString();
    }
}
