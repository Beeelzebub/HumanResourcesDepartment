using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class BusinessTrip : Action
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Пункт назначения")]
        public string Destination { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата начала")]
        public DateTime? TripStartDate { get; set; }
        
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата окончания")]
        public DateTime? TripEndDate { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Цель")]
        public string Purpose { get; set; }

        public override string GetActionName() => "Командировка";
        public override string GetDescription() =>
            "<strong>Пункт назначения: </strong>" + Destination +
            "<br /><strong>Цель: </strong>" + Purpose +
            "<br /><strong>Дата начала: </strong>" + TripStartDate?.ToShortDateString() +
            "<br /><strong>Дата окончания: </strong>" + TripEndDate?.ToShortDateString();
    }
}
