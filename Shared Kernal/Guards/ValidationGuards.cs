using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared_Kernal.Guards
{
    //generic guard class for validating input parameters
    public static class Guard
    {
        public static class Against
        {
            public static void NullOrWhiteSpace(string s, string ParamName)
            {
                if (string.IsNullOrWhiteSpace(s))
                    throw new BusinessLogicException($"The Property {ParamName} is null or empty");
            }

            public static void ValidateEmail(string email, string ParamName)
            {
                if (!email.Contains("@"))
                    throw new BusinessLogicException($"The Property {ParamName} is not a valid email");
            }

            public static void ValidatePhone(string input, string ParamName)
            {
                if (!Regex.IsMatch(input, @"^\d+$"))
                {
                    throw new ArgumentException("Should be a valid mobile!", ParamName);
                }
            }

            public static void CantBeNegative(int value, string paramName)
            {
                if (value < 0)
                    throw new BusinessLogicException($"The Property {paramName} can't be negative");
            }

            public static void CantBeNegative(decimal value, string paramName)
            {
                if (value < 0)
                    throw new BusinessLogicException($"The Property {paramName} can't be negative");
            }
        }
    }
}
