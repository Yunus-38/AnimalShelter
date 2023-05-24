using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeArchive : IEntity
    {
        public int EmployeeArchiveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TerminationDate { get; set; }
    }
}
