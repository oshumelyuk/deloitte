using Deloitte.DAL;
using Deloitte.DAL.Interfaces;
using DryIoc;

namespace Deloitte.Web.App_Start
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies(IContainer container)
        {
            container.Register<IUserRepository, UserRepository>(Reuse.Singleton);
            container.Register<IAccountRepository, AccountRepository>(Reuse.Singleton);
        }
    }
}