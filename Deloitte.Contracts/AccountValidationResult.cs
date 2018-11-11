using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Contracts
{
    public class AccountValidationResult
    {
        public bool IsValid { get; set; }

        public AccountData Account { get; set; }
    }
}
