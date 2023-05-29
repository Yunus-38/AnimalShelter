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
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.AddCitySuccess);
        }

        public IResult Delete(int cityId)
        {
            var city = GetById(cityId).Data;
            if (city == null)
                return new ErrorResult(Messages.CityNotFound);

            _cityDal.Delete(city);
            return new SuccessResult(Messages.DeleteCitySuccess);
        }

        public IDataResult<List<City>> GetAll()
        {
            var cities = _cityDal.GetAll();
            return new SuccessDataResult<List<City>>(cities, Messages.GetCityListSuccess);
        }

        public IDataResult<City> GetById(int cityId)
        {
            var city = _cityDal.Get(c => c.CityId == cityId);
            if (city == null)
                return new ErrorDataResult<City>(Messages.CityNotFound);

            return new SuccessDataResult<City>(city, Messages.GetCitySuccess);
        }

        public IResult Update(int cityId, City city)
        {
            var currentCity = GetById(cityId).Data;
            if (currentCity == null)
                return new ErrorResult(Messages.CityNotFound);

            

            _cityDal.Update(city);
            return new SuccessResult(Messages.UpdateCitySuccess);
        }
    }

}
