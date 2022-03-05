using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Catalogo.Core.Exceptions
{
    public class DomainException : Exception
    {
        internal List<string> _errors;

        public List<string> Errors => _errors;

        public DomainException()
        {
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}