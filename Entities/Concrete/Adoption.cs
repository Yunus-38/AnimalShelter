using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Adoption : IEntity
    {
        public int AdoptionId { get; set; }
        public int AdopterId { get; set; }
        public int AnimalId { get; set; }
        public DateTime AdoptionDate { get; set; }
    }
}
