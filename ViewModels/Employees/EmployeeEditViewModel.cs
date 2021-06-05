using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Patronymic { get; set; }

        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Номер паспорта")]
        [RegularExpression(@"[A-Z]{2}[0-9]{7}", ErrorMessage = "Некорректный ввод")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string PassportID { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime DOB { get; set; }
        public bool IsEdited { get; set; }
    }
}
