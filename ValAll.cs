using System;

namespace Bikiran.Validation
{
    public class ValAll
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
    }
}
