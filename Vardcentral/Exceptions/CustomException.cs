using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vardcentral.Exceptions
{
    public class CustomException : Exception
    {
        private static readonly string DefaultMessage = "Something went wrong";
        public CustomException() : base(DefaultMessage)
        {

        }

        public CustomException(string message) : base(message)
        {

        }
    }
}
