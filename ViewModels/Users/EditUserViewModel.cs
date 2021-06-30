using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels.Users
{
    public class EditUserViewModel : UserViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Id { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string Password { get; set; }
    }
}
