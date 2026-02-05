using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Abstraction
{
    public interface IPersistanceDto<E>
    {
        public E toEntity();
    }
}
