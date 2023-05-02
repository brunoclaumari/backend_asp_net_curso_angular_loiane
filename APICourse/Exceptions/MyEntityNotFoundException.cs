using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICourse.Exceptions
{
    public class MyEntityNotFoundException : Exception
    {
        public MyEntityNotFoundException()
        {
        }

        public MyEntityNotFoundException(string message) : base(message)
        {
        }



    }
}
