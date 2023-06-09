﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAnimalDal : IEntityRepository<Animal>
    {
        public List<GetAdoptedAnimalsDto> GetAdoptedAnimals(Expression<Func<GetAdoptedAnimalsDto, bool>> filter = null);
        public AnimalDetailsDto GetAnimalDetails(Expression<Func<AnimalDetailsDto, bool>> filter);
        public List<AnimalDetailsDto> GetAllAnimalDetails(int id);
    }

}
