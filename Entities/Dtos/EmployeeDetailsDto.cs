using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class EmployeeDetailsDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public int EmployeeWage { get; set; }
        public int EmployeeIsActive { get; set; }
        public string ShelterName { get; set; }
        public string PositionName { get; set; }
    }
}
