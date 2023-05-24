using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Animal : IEntity
    {
        public int AnimalId { get; set; }
        public int ShelterId { get; set; }
        public int GenusId { get; set; }
        public string AnimalName { get; set; }
        public int IsAdopted { get; set; } = 0;
        public DateTime BirthDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string Sex { get; set; }

    }
}
