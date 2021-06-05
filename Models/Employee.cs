using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool IsDismissed { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportID { get; set; }
        public DateTime DOB { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public float Salary { get; set; }
        public string GetFullName() => Surname + " " + FirstName[0] + "." + Patronymic[0] + ".";
    }
}
