using System;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        internal List<string> _errors { get; set; }

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}