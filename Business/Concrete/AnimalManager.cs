using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AnimalManager : IAnimalService
    {
        private readonly IAnimalDal _animalDal;

        public AnimalManager(IAnimalDal animalDal)
        {
            _animalDal = animalDal;
        }

        public IResult Add(Animal animal)
        {
            _animalDal.Add(animal);
            return new SuccessResult(Messages.AddAnimalSuccess);
        }

        public IResult Delete(int animalId)
        {
            var animal = GetById(animalId).Data;
            if (animal == null)
                return new ErrorResult(Messages.AnimalNotFound);

            _animalDal.Delete(animal);
            return new SuccessResult(Messages.DeleteAnimalSuccess);
        }

        public IDataResult<List<Animal>> GetAll()
        {
            var animals = _animalDal.GetAll();
            return new SuccessDataResult<List<Animal>>(animals, Messages.GetAnimalListSuccess);
        }

        public IDataResult<Animal> GetById(int animalId)
        {
            var animal = _animalDal.Get(a => a.AnimalId == animalId);
            if (animal == null)
                return new ErrorDataResult<Animal>(Messages.AnimalNotFound);

            return new SuccessDataResult<Animal>(animal, Messages.GetAnimalSuccess);
        }

        public IResult Update(int id, Animal animal)
        {
            var currentAnimal = _animalDal.Get(a => a.AnimalId == id);
            if (currentAnimal == null)
                return new ErrorResult(Messages.AnimalNotFound);

            var propertyInfo = typeof(Animal).GetProperties();
            foreach (var property in propertyInfo)
            {
                var propertyValue = property.GetValue(animal);
                bool isNullOrEmpty = propertyValue == null || (propertyValue is string && string.IsNullOrEmpty((string)propertyValue));
                if (isNullOrEmpty)
                {
                    property.SetValue(currentAnimal, property.GetValue(currentAnimal));
                }
                else
                {
                    property.SetValue(currentAnimal, propertyValue);
                }
            }

            _animalDal.Update(currentAnimal);
            return new SuccessResult(Messages.UpdateAnimalSuccess);
        }


        public IDataResult<List<Animal>> GetAnimalsByAdopterId(int adopterId)
        {
            throw new NotImplementedException();
        }

        public IResult Adopt(int animalId, int adopterId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AnimalDetailsDto> GetAnimalDetailsById(int animalId)
        {
            var animalDetails = _animalDal.GetAnimalDetails(a => a.AnimalId == animalId);
            if (animalDetails == null)
            {
                return new ErrorDataResult<AnimalDetailsDto>(Messages.AnimalNotFound);
            }
            return new SuccessDataResult<AnimalDetailsDto>(animalDetails, Messages.GetAnimalSuccess);
        }

        public IDataResult<List<GetAdoptedAnimalsDto>> GetAdoptedAnimals()
        {
            var animals = _animalDal.GetAdoptedAnimals();
            return new SuccessDataResult<List<GetAdoptedAnimalsDto>>(animals, Messages.GetAnimalListSuccess);
        }
    }

}
