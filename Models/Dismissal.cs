using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Dismissal : Action
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата составления")]
        public DateTime? DateOfPreparation { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Дата увольнения")]
        public DateTime? DateOfDismissal { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Основание")]
        public string Reason { get; set; }


        public override string GetActionName() => "Увольнение";
        public override string GetDescription() =>
            "<strong>Основание: </strong>" + Reason +
            "<br /><strong>Дата составления: </strong>" + DateOfPreparation?.ToShortDateString() +
            "<br /><strong>Дата увольнения: </strong>" + DateOfDismissal?.ToShortDateString();
    }
}
