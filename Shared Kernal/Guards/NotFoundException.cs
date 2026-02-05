using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Kernal.Guards
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException() : base("Requested resource was not found")
        {
        }
    }
}
