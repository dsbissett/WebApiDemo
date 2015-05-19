using Business.Interfaces;
using Business.Methods;
using Business.Models;
using Ninject.Modules;

namespace Business
{
    public class Business : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonModel>().To<PersonModel>();
            Bind<IPersonLogic>().To<PersonLogic>();
        }
    }
}