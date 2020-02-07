using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Domain.Exceptions
{
    public class ProjectDemoValidationException : Exception
    {
        public ProjectDemoValidationException(string message) : base(message)
        {
        }
    }
}
