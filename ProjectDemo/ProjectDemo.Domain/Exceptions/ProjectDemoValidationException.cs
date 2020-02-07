using System;

namespace ProjectDemo.Domain.Exceptions
{
    public class ProjectDemoValidationException : Exception
    {
        public ProjectDemoValidationException(string message) : base(message)
        {
        }
    }
}
