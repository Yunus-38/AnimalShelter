using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public int ShelterId { get; set; }
        public int PositionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int IsActive { get; set; } = 1;
        public int Wage { get; set; }
    }
}
