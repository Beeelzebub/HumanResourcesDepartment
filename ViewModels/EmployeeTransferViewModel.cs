using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels
{
    public class EmployeeTransferViewModel
    {
        public int EmployeeId { get; set; }
        public int NewDepartmentId { get; set; }
        public int NewPostId { get; set; }
        public float NewSalary { get; set; }
        public DateTime DateOfTransfer { get; set; }
    }
}
