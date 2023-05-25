using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class EmployeePositionDto
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
        public int EmployeeWage { get; set; }
    }
}
