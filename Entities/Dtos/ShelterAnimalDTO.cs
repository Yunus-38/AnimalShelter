using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ShelterAnimalDTO
    {
        public string CityName { get; set; }
        public string ShelterName { get; set; }
        public string SpeciesName { get; set; }
        public string GenusName { get; set; }
        public string AnimalGender { get; set; }
        public string AnimalName { get; set; }
        public DateTime AnimalBirthDate { get; set; }
        public string ShelterAddress { get; set; }

    }
}
