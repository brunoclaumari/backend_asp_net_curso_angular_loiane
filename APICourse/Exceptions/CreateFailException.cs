using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICourse.Exceptions
{
    public class CreateFailException : Exception
    {
        public CreateFailException(string message) : base(message)
        {
        }
    }
}
