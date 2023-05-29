using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetEmployeesByShelterDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeWage { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public int ShelterId { get; set; }

    }
}
