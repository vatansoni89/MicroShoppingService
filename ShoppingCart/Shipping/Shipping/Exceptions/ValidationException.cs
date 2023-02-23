using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shipping.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IReadOnlyDictionary<string, string[]> failures)
            : this()
        {
            Errors = failures;
        }

        public IReadOnlyDictionary<string, string[]> Errors { get; }
    }
}
