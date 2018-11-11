using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.DAL.Interfaces
{
    public interface ILogger
    {
        Task LogAsync(Exception e);

        Task LogAsync(string message);
    }
}
