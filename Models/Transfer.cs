using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Transfer : Action
    {
        public int OldDepartmentId { get; set; }
        public int OldPostId { get; set; }
        public int NewDepartmentId { get; set; }
        public int NewPostId { get; set; }
        public DateTime? DateOfTransfer { get; set; }
        public float NewSalary { get; set; }

        [NotMapped]
        public Department OldDepartment { get; set; }
        [NotMapped]
        public Department NewDepartment { get; set; }
        [NotMapped]
        public Post OldPost { get; set; }
        [NotMapped]
        public Post NewPost { get; set; }

        public override string GetActionName() => "Перевод";
        public override string GetDescription() =>
            "<strong>Предыдущий отдел: </strong>" + OldDepartment.Name +
            "<br /><strong>Предыдущая должность: </strong>" + OldPost.PostName +
            "<br /><strong>Новый отдел: </strong>" + NewDepartment.Name +
            "<br /><strong>Новая должность: </strong>" + NewPost.PostName +
            "<br /><strong>Новый оклад: </strong>" + NewSalary + "бр.";
    }
}
