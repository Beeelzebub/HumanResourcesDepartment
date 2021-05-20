using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.ViewModels
{
    public class LaborContractViewModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportID { get; set; }
        public DateTime DOB { get; set; }
        public int DepartmentId { get; set; }
        public int PostId { get; set; }
        public string Experience { get; set; }
        public virtual IFormFile Image { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateOfPreparation { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public float Salary { get; set; }
        public string Base { get; set; }
    }
}
