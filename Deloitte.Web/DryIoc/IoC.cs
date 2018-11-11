using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DryIoc;

namespace Deloitte.Web.DryIoc
{
    public static class IoC
    {
        public static Container Instance => new Container();
    }
}