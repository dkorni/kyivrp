using System;
using System.Collections.Generic;
using System.Text;

namespace KyivRP.Domain.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
