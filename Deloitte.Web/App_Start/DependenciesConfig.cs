using Deloitte.DAL;
using Deloitte.DAL.Interfaces;
using Deloitte.Web.DryIoc;
using DryIoc;

namespace Deloitte.Web.App_Start
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies()
        {
            IoC.Instance.Register<IUserRepository, UserRepository>(Reuse.Singleton);
            IoC.Instance.Register<IAccountRepository, AccountRepository>(Reuse.Singleton);
        }
    }
}