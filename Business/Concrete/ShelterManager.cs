using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShelterManager : IShelterService
    {
        private readonly IShelterDal _shelterDal;

        public ShelterManager(IShelterDal shelterDal)
        {
            _shelterDal = shelterDal;
        }

        public IResult Add(Shelter shelter)
        {
            _shelterDal.Add(shelter);
            return new SuccessResult(Messages.AddShelterSuccess);
        }

        public IResult Delete(int id)
        {
            var shelter = GetById(id).Data;
            if (shelter == null)
            {
                return new ErrorResult(Messages.ShelterNotFound);
            }

            _shelterDal.Delete(shelter);
            return new SuccessResult(Messages.DeleteShelterSuccess);
        }

        public IDataResult<List<Shelter>> GetAll()
        {
            var shelters = _shelterDal.GetAll();
            return new SuccessDataResult<List<Shelter>>(shelters, Messages.GetShelterListSuccess);
        }

        public IDataResult<Shelter> GetById(int id)
        {
            var shelter = _shelterDal.Get(s => s.ShelterId == id);
            if (shelter == null)
            {
                return new ErrorDataResult<Shelter>(Messages.ShelterNotFound);
            }

            return new SuccessDataResult<Shelter>(shelter, Messages.GetShelterSuccess);
        }

        public IDataResult<List<Animal>> GetShelterAnimals(int shelterId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(int id, Shelter shelter)
        {
            var currentShelter = _shelterDal.Get(s => s.ShelterId == id);
            if (currentShelter == null)
            {
                return new ErrorResult(Messages.ShelterNotFound);
            }

            Shelter newShelter = new Shelter();
            var propertyInfo = typeof(Shelter).GetProperties();

            foreach (var property in propertyInfo)
            {
                var propertyValue = property.GetValue(shelter);
                if (propertyValue is null || propertyValue.Equals(0) || propertyValue.Equals((double)0) || propertyValue.Equals(new DateTime()))
                {
                    property.SetValue(newShelter, property.GetValue(currentShelter));
                }
                else
                {
                    property.SetValue(newShelter, property.GetValue(shelter));
                }
            }

            newShelter.ShelterId = currentShelter.ShelterId; // Preserve the ID

            _shelterDal.Update(newShelter);
            return new SuccessResult(Messages.UpdateShelterSuccess);
        }
    }

}
