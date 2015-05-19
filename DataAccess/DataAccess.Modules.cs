using DataAccess.Interfaces;
using DataAccess.Repositories;
using Ninject.Modules;
using SharpRepository.Ioc.Ninject;

namespace DataAccess
{
    public class DataAccess : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonRepository>().To<PersonRepository>();
            //Kernel.BindSharpRepository();
        }
    }
}