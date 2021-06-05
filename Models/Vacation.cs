using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Vacation : Action
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата составления")]
        public DateTime? DateOfPreparation { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата начала")]
        public DateTime? VacationStartDate { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата окончания")]
        public DateTime? VacationEndDate { get; set; }

        public override string GetActionName() => "Отпуск";
        public override string GetDescription() =>
            "<strong>Дата составления: </strong>" + DateOfPreparation?.ToShortDateString() +
            "<br /><strong>Дата начала: </strong>" + VacationStartDate?.ToShortDateString() +
            "<br /><strong>Дата окончания: </strong>" + VacationEndDate?.ToShortDateString();

    }
}
