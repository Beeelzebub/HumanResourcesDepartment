using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Transfer> Transfers { get; set; }
        public Department()
        {
            Transfers = new List<Transfer>();
        }
    }
}
