using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public abstract class Action : IComparable<Action>
    {
        public int Id { get; set; }
        public User HRManager { get; set; }
        public DateTime DateOfAction { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public abstract string GetActionName();
        public abstract string GetDescription();

        public int CompareTo(Action otherAction)
        {
            return otherAction.DateOfAction.CompareTo(DateOfAction);
        }
    }
}
