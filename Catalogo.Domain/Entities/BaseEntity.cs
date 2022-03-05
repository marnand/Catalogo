using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public abstract class BaseEntity
    {
        internal List<string> _errors { get; set; }

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}