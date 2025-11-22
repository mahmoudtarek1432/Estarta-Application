using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Kernal.Guards
{
    public class UnProcessableEntityException : Exception
    {
        public UnProcessableEntityException(string? message) : base(message)
        {
        }
    }
}
