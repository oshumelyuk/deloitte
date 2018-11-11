using Deloitte.DAL.Interfaces;

namespace Deloitte.DAL
{
    public static class Logger
    {
        public static ILogger Instance => new FileLogger();
    }
}
