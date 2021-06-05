using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels
{
    public class EmployeeTransferViewModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Новый отдел")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int NewDepartmentId { get; set; }

        [Display(Name = "Новая должность")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int NewPostId { get; set; }

        [Display(Name = "Новый оклад")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public float NewSalary { get; set; }

        [Display(Name = "Дата перевода")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime DateOfTransfer { get; set; }
    }
}
