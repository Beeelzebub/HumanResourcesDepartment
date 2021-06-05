using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels
{
    public class LaborContractViewModel
    {
        [Display(Name = "Фотография")]
        [Required(ErrorMessage = "Загрузите изображение")]
        public virtual IFormFile Image { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string FirstName { get; set; }
        
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Surname { get; set; }

        [Display(Name = "отчество")]
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

        [Display(Name = "Название компании")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string CompanyName { get; set; }

        [Display(Name = "Отдел")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int DepartmentId { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int PostId { get; set; }

        [Display(Name = "Оклад")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public float Salary { get; set; }

        [Display(Name = "Основание")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Base { get; set; }

        [Display(Name = "Дата составления")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime DateOfPreparation { get; set; }

        [Display(Name = "Дата принятия")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime DateOfAdoption { get; set; }

    }
}
