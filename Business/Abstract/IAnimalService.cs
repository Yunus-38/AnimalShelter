﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnimalService
    {
        IDataResult<List<Animal>> GetAll();
        IDataResult<Animal> GetById(int animalId);
        IResult Add(Animal animal);
        IResult Delete(int animalId);
        IResult Update(int animalId, Animal animal);
        IDataResult<List<Animal>> GetAnimalsByAdopterId(int adopterId);
        IResult Adopt(int animalId, int adopterId);
        IDataResult<AnimalDetailsDto> GetAnimalDetailsById(int animalId);
        IDataResult<List<GetAdoptedAnimalsDto>> GetAllAdoptedAnimals();
        IDataResult<List<GetAdoptedAnimalsDto>> GetAdoptedAnimalsByAdopterId(int adopterId);
        public IDataResult<List<AnimalDetailsDto>> GetAnimalsByShelterId(int id);
    }


}
