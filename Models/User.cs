using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesDepartment.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string GetFullName() => Surname + " " + FirstName[0] + "." + Patronymic[0] + ".";
    }
}
