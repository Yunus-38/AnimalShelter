using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public class SpeciesManager : ISpeciesService
    {
        private readonly ISpeciesDal _speciesDal;

        public SpeciesManager(ISpeciesDal speciesDal)
        {
            _speciesDal = speciesDal;
        }

        public IResult Add(Species species)
        {
            _speciesDal.Add(species);
            return new SuccessResult(Messages.AddSpeciesSuccess);
        }

        public IResult Delete(int id)
        {
            var species = GetById(id).Data;
            if (species == null)
            {
                return new ErrorResult(Messages.SpeciesNotFound);
            }

            _speciesDal.Delete(species);
            return new SuccessResult(Messages.DeleteSpeciesSuccess);
        }

        public IDataResult<List<Species>> GetAll()
        {
            var speciesList = _speciesDal.GetAll();
            return new SuccessDataResult<List<Species>>(speciesList, Messages.GetSpeciesListSuccess);
        }

        public IDataResult<Species> GetById(int id)
        {
            var species = _speciesDal.Get(s => s.SpeciesId == id);
            if (species == null)
            {
                return new ErrorDataResult<Species>(Messages.SpeciesNotFound);
            }

            return new SuccessDataResult<Species>(species, Messages.GetSpeciesSuccess);
        }

        public IDataResult<List<Genus>> GetSpeciesGenera(int speciesId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(int id, Species species)
        {
            var currentSpecies = _speciesDal.Get(s => s.SpeciesId == id);
            if (currentSpecies == null)
            {
                return new ErrorResult(Messages.SpeciesNotFound);
            }

            Species newSpecies = new Species();
            var propertyInfo = typeof(Species).GetProperties();

            foreach (var property in propertyInfo)
            {
                var propertyValue = property.GetValue(species);
                if (propertyValue is null || propertyValue.Equals(0) || propertyValue.Equals((double)0) || propertyValue.Equals(new DateTime()))
                {
                    property.SetValue(newSpecies, property.GetValue(currentSpecies));
                }
                else
                {
                    property.SetValue(newSpecies, property.GetValue(species));
                }
            }

            newSpecies.SpeciesId = currentSpecies.SpeciesId; // Preserve the ID

            _speciesDal.Update(newSpecies);
            return new SuccessResult(Messages.UpdateSpeciesSuccess);
        }
    }

}
