using Ninject.Modules;
using Infrastructure.Repositories;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Services
{
    public class DepInjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Person>>().To<Repository<Person>>();
            Bind<IRepository<Address>>().To<Repository<Address>>();

        }

    }
}
