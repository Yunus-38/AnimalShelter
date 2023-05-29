using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetAdoptedAnimalsDto
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string AnimalSex { get; set; }
        public DateTime AnimalBirthDate { get; set; }
        public int AnimalAge { get; set; }
        public string AdopterName { get; set; }
        public string AdopterIdNumber { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string AdopterPhoneNumber { get; set; }
        public string AdopterAddress { get; set; }
        public string CityName { get; set; }
        public string ShelterName { get; set; }
        public string ShelterAddress { get; set; }
        public int AdopterId { get; set; }
    }
}
