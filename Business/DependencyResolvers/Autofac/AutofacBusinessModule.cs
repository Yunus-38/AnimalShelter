using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities.Interceptors.MethodInterception;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalManager>().As<IAnimalService>().SingleInstance();
            builder.RegisterType<EfAnimalDal>().As<IAnimalDal>().SingleInstance();

            builder.RegisterType<AdopterManager>().As<IAdopterService>().SingleInstance();
            builder.RegisterType<EfAdopterDal>().As<IAdopterDal>().SingleInstance();

            builder.RegisterType<AdoptionManager>().As<IAdoptionService>().SingleInstance();
            builder.RegisterType<EfAdoptionDal>().As<IAdoptionDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<EmployeeArchiveManager>().As<IEmployeeArchiveService>().SingleInstance();
            builder.RegisterType<EfEmployeeArchiveDal>().As<IEmployeeArchiveDal>().SingleInstance();

            builder.RegisterType<GenusManager>().As<IGenusService>().SingleInstance();
            builder.RegisterType<EfGenusDal>().As<IGenusDal>().SingleInstance();

            builder.RegisterType<PositionManager>().As<IPositionService>().SingleInstance();
            builder.RegisterType<EfPositionDal>().As<IPositionDal>().SingleInstance();

            builder.RegisterType<ShelterManager>().As<IShelterService>().SingleInstance();
            builder.RegisterType<EfShelterDal>().As<IShelterDal>().SingleInstance();

            builder.RegisterType<SpeciesManager>().As<ISpeciesService>().SingleInstance();
            builder.RegisterType<EfSpeciesDal>().As<ISpeciesDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }

}
