using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class SickLeave : Action
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата начала")]
        public DateTime? SickLeaveStartDate { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата окончания")]
        public DateTime? SickLeaveEndDate { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Причина")]
        public string SickLeaveReason { get; set; }

        public override string GetActionName() => "Больничный";
        public override string GetDescription() => 
            "<strong>Причина: </strong>" + SickLeaveReason +
            "<br /><strong>Дата начала: </strong>" + SickLeaveStartDate?.ToShortDateString() +
            "<br /><strong>Дата окончания: </strong>" + SickLeaveEndDate?.ToShortDateString();
    }
}
