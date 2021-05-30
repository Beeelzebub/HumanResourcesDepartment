using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels
{
    public class ActionsFilterViewModel
    {
        public string HRManagerId { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public int EmployeeId { get; set; }
    }
}
