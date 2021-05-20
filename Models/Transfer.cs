using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public int OldDepartmentId { get; set; }
        public int OldPostId { get; set; }
        public int NewDepartmentId { get; set; }
        public int NewPostId { get; set; }
        public DateTime DateOfTransfer { get; set; }
        public int EmployeeId { get; set; }
        public float NewSalary { get; set; }
        public Employee Employee { get; set; }
    }
}
