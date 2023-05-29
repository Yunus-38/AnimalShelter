using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdopterDal : EfEntityRepositoryBase<Adopter, ProjectContext>, IAdopterDal
    {
    }

}
