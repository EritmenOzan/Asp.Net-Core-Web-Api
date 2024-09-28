using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public abstract class NotFoundExecption : Exception
    {
        protected NotFoundExecption(string message) : base(message)
        {

        }
    }
}

namespace Entities.Exceptions
{
}