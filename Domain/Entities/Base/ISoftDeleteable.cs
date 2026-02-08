using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Base
{
    public interface ISoftDeleteable
    {
        public abstract bool IsDeleted { get; set; }
    }
}
