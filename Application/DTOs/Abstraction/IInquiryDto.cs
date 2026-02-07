using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Abstraction
{
    public interface IInquiryDto<E, RDto>
    {
        public static abstract RDto FromEntity(E entity);
    }
}
