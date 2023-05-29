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
    public class AdoptionManager : IAdoptionService
    {
        private readonly IAdoptionDal _adoptionDal;

        public AdoptionManager(IAdoptionDal adoptionDal)
        {
            _adoptionDal = adoptionDal;
        }

        public IResult Add(Adoption adoption)
        {
            _adoptionDal.Add(adoption);
            return new SuccessResult(Messages.AddAdoptionSuccess);
        }

        public IResult Delete(int adoptionId)
        {
            var adoption = GetById(adoptionId).Data;
            if (adoption == null)
                return new ErrorResult(Messages.AdoptionNotFound);

            _adoptionDal.Delete(adoption);
            return new SuccessResult(Messages.DeleteAdoptionSuccess);
        }

        public IDataResult<List<Adoption>> GetAll()
        {
            var adoptions = _adoptionDal.GetAll();
            return new SuccessDataResult<List<Adoption>>(adoptions, Messages.GetAdoptionListSuccess);
        }

        public IDataResult<Adoption> GetById(int adoptionId)
        {
            var adoption = _adoptionDal.Get(a => a.AdoptionId == adoptionId);
            if (adoption == null)
                return new ErrorDataResult<Adoption>(Messages.AdoptionNotFound);

            return new SuccessDataResult<Adoption>(adoption, Messages.GetAdoptionSuccess);
        }

        public IResult Update(int adoptionId, Adoption adoption)
        {
            var currentAdoption = GetById(adoptionId).Data;
            if (currentAdoption == null)
                return new ErrorResult(Messages.AdoptionNotFound);

            

            _adoptionDal.Update(adoption);
            return new SuccessResult(Messages.UpdateAdoptionSuccess);
        }
    }

}
