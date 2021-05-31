using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Transfer : Action
    {
        public int Id { get; set; }
        public int OldDepartmentId { get; set; }
        public int OldPostId { get; set; }
        public int NewDepartmentId { get; set; }
        public int NewPostId { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public int EmployeeId { get; set; }
        public float NewSalary { get; set; }
        public List<Department> Departments { get; set; }
        public List<Post> Posts { get; set; }
        public override Employee Employee { get; set; }

        public override string GetActionName() => "Перевод";
        public override string GetDescription() => 
            "Предыдущий отдел: " + Departments.FirstOrDefault(d => d.Id == OldDepartmentId).Name +
            "\nПредыдущая должность: " + Posts.FirstOrDefault(p => p.Id == OldPostId).PostName +
            "\nНовый отдел: " + Departments.FirstOrDefault(d => d.Id == NewDepartmentId).Name +
            "\nНовая должность: " + Posts.FirstOrDefault(p => p.Id == NewPostId).PostName +
            "\nНовый оклад: " + NewSalary + "бр.";
    }
}
