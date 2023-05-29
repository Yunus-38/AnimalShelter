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
    public class AdopterManager : IAdopterService
    {
        private readonly IAdopterDal _adopterDal;

        public AdopterManager(IAdopterDal adopterDal)
        {
            _adopterDal = adopterDal;
        }

        public IResult Add(Adopter adopter)
        {
            _adopterDal.Add(adopter);
            return new SuccessResult(Messages.AddAdopterSuccess);
        }

        public IResult Delete(int adopterId)
        {
            var adopter = GetById(adopterId).Data;
            if (adopter == null)
                return new ErrorResult(Messages.AdopterNotFound);

            _adopterDal.Delete(adopter);
            return new SuccessResult(Messages.DeleteAdopterSuccess);
        }

        public IDataResult<List<Animal>> GetAdopterAnimals(int adopterId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Adopter>> GetAll()
        {
            var adopters = _adopterDal.GetAll();
            return new SuccessDataResult<List<Adopter>>(adopters, Messages.GetAdopterListSuccess);
        }

        public IDataResult<Adopter> GetById(int adopterId)
        {
            var adopter = _adopterDal.Get(a => a.AdopterId == adopterId);
            if (adopter == null)
                return new ErrorDataResult<Adopter>(Messages.AdopterNotFound);

            return new SuccessDataResult<Adopter>(adopter, Messages.GetAdopterSuccess);
        }

        public IResult Update(int adopterId, Adopter adopter)
        {
            var currentAdopter = GetById(adopterId).Data;
            if (currentAdopter == null)
                return new ErrorResult(Messages.AdopterNotFound);

            

            _adopterDal.Update(adopter);
            return new SuccessResult(Messages.UpdateAdopterSuccess);
        }
    }

}
