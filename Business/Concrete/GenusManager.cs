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
    public class GenusManager : IGenusService
    {
        private readonly IGenusDal _genusDal;

        public GenusManager(IGenusDal genusDal)
        {
            _genusDal = genusDal;
        }

        public IResult Add(Genus genus)
        {
            _genusDal.Add(genus);
            return new SuccessResult(Messages.AddGenusSuccess);
        }

        public IResult Delete(int id)
        {
            var genus = GetById(id).Data;
            if (genus == null)
            {
                return new ErrorResult(Messages.GenusNotFound);
            }

            _genusDal.Delete(genus);
            return new SuccessResult(Messages.DeleteGenusSuccess);
        }

        public IDataResult<List<Genus>> GetAll()
        {
            var genusList = _genusDal.GetAll();
            return new SuccessDataResult<List<Genus>>(genusList, Messages.GetGenusListSuccess);
        }

        public IDataResult<Genus> GetById(int id)
        {
            var genus = _genusDal.Get(g => g.GenusId == id);
            if (genus == null)
            {
                return new ErrorDataResult<Genus>(Messages.GenusNotFound);
            }

            return new SuccessDataResult<Genus>(genus, Messages.GetGenusSuccess);
        }

        public IResult Update(int id, Genus genus)
        {
            var currentGenus = _genusDal.Get(g => g.GenusId == id);
            if (currentGenus == null)
            {
                return new ErrorResult(Messages.GenusNotFound);
            }

            Genus newGenus = new Genus();
            var propertyInfo = typeof(Genus).GetProperties();

            foreach (var property in propertyInfo)
            {
                var propertyValue = property.GetValue(genus);
                if (propertyValue is null || propertyValue.Equals(0) || propertyValue.Equals((double)0) || propertyValue.Equals(new DateTime()))
                {
                    property.SetValue(newGenus, property.GetValue(currentGenus));
                }
                else
                {
                    property.SetValue(newGenus, property.GetValue(genus));
                }
            }

            newGenus.GenusId = currentGenus.GenusId; // Preserve the ID

            _genusDal.Update(newGenus);
            return new SuccessResult(Messages.UpdateGenusSuccess);
        }
    }

}
