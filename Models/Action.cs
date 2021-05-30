using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public abstract class Action
    {
        public User HRManager { get; set; }
        public DateTime DateOfAction { get; set; }
        public abstract Employee Employee { get; set; }
        public abstract string GetActionName();
        public abstract string GetDescription();
    }
}
