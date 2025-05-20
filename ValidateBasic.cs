using System;
using System.Collections.Generic;

namespace Bikiran.Validation
{
    public class ValidateBasic
    {
        public static ValidateStatus ValidateAll(List<ValidateStatus> parameters)
        {
            var x = 0;
            foreach (var parameter in parameters)
            {
                if (parameter.Error)
                {
                    return new ValidateStatus { Error = parameter.Error, Message = parameter.Message, ErrorIndex = x };
                }
                x++;
            }

            return new ValidateStatus { Error = false, Message = "Success", ErrorIndex = -1 };
        }

        public static string GetReferenceName(List<string> refNames, int errorIndex)
        {
            if (errorIndex == -1)
            {
                return "";
            }

            if (errorIndex >= refNames.Count)
            {
                return "";
            }

            return refNames[errorIndex];
        }
    }
}
