using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAnimalDal : EfEntityRepositoryBase<Animal, ProjectContext>, IAnimalDal
    {
        public AnimalDetailsDto GetAnimalDetails(Expression<Func<AnimalDetailsDto, bool>> filter)
        {
            using (var context = new ProjectContext())
            {
                var result = from a in context.Animals
                             join s in context.Shelters
                             on a.ShelterId equals s.ShelterId
                             join g in context.Genera
                             on a.GenusId equals g.GenusId
                             join sp in context.Species
                             on g.SpeciesId equals sp.SpeciesId
                             select new AnimalDetailsDto
                             {
                                 AnimalId = a.AnimalId,
                                 AnimalName = a.AnimalName,
                                 AnimalAge = DateTime.Now.Year - a.BirthDate.Year,
                                 AnimalBirthDate = a.BirthDate,
                                 AnimalEntryDate = a.EntryDate,
                                 AnimalSex = a.Sex,
                                 GenusName = g.GenusName,
                                 ShelterName = s.ShelterName,
                                 SpeciesName = sp.SpeciesName,
                             };

                return result.SingleOrDefault(filter);
            }
        }

        public List<GetAdoptedAnimalsDto> GetAdoptedAnimals()
        {
            using (var context = new ProjectContext())
            {
                var result = from a in context.Animals
                             join adoption in context.Adoptions
                             on a.AnimalId equals adoption.AnimalId
                             join adopter in context.Adopters
                             on adoption.AdoptionId equals adopter.AdopterId
                             join s in context.Shelters
                             on a.ShelterId equals s.ShelterId
                             join c in context.Cities
                             on s.CityId equals c.CityId
                             join g in context.Genera
                             on a.GenusId equals g.GenusId
                             join sp in context.Species
                             on g.SpeciesId equals sp.SpeciesId
                             where a.IsAdopted == 1
                             select new GetAdoptedAnimalsDto
                             {
                                 AnimalId = a.AnimalId,
                                 AnimalName = a.AnimalName,
                                 AnimalAge = DateTime.Now.Year - a.BirthDate.Year,
                                 AnimalBirthDate = a.BirthDate,
                                 AnimalSex = a.Sex,
                                 AdopterName = adopter.FirstName + " " + adopter.LastName,
                                 AdopterIdNumber = adopter.IdNumber,
                                 AdopterAddress = adopter.Address,
                                 AdopterPhoneNumber = adopter.PhoneNumber,
                                 AdoptionDate = adoption.AdoptionDate
                             };

                return result.ToList();
            }
        }


    }
}
