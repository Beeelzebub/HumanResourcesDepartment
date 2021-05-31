using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class BusinessTrip : Action
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public override Employee Employee { get; set; }
        public string Destination { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripEndDate { get; set; }
        public string Purpose { get; set; }

        public override string GetActionName() => "Командировка";
        public override string GetDescription() => 
            "Пункт назначения: " + Destination + 
            "\nЦель: " + Purpose +
            "\nДата начала: " + TripStartDate.ToShortDateString() +
            "\nДата окончания: " + TripEndDate.ToShortDateString();
    }
}
