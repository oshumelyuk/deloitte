using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.DAL
{
    public static class DeloitteHostingEnvironment
    {
        private static Func<string, string> pathTransformer;

        public static void Set(Func<string, string> transformer)
        {
            pathTransformer = transformer;
        }

        public static string Get(string relativeUrl)
        {
            if (pathTransformer != null)
            {
                return pathTransformer(relativeUrl);
            }
            return relativeUrl;
        }
    }
}
