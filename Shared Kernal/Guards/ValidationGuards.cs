using System.Text.RegularExpressions;

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

            public static void NullOrEmpty(Guid input, string ParamName)
            {
                if (input != Guid.Empty || input == null)
                    throw new BusinessLogicException($"The Property {ParamName} is null or empty");
            }

            public static void ValidateEmail(string email, string ParamName)
            {
                if (!email.Contains("@"))
                    throw new BusinessLogicException($"The Property {ParamName} is not a valid email");
            }

            public static void ValidatePhone(string input, string ParamName)
            {
                if (!Regex.IsMatch(input, @"^(?:\+20|20|0)?1[0125][0-9]{8}"))
                {
                    throw new ArgumentException("Should be a valid mobile!", ParamName);
                }
            }

            public static void NotAlphaNumeric(string input, string ParamName)
            {
                if (!Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
                {
                    throw new BusinessLogicException($"The Property {ParamName} Should be Alpha numeric.");
                }
            }

            public static void NotWithinRange(string input, int min, int max, string ParamName)
            {
                if (input.Length > max || input.Length < min)
                    throw new BusinessLogicException($"The Property {ParamName} Should Fall Withing Range ({min} ~ {max}).");
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
