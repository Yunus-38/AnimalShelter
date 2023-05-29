using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Shelter : IEntity
    {
        public int ShelterId { get; set; }
        public int CityId { get; set; }
        public string ShelterName { get; set; }
        public string ShelterAddress { get; set; }
        public int Capacity { get; set; } = 100;
    }
}
