using System;

namespace Bikiran.Validation
{
    public class ValAll
    {
        public static StatusObj ValidateAll(List<StatusObj> parameters)
        {
            var x = 0;
            foreach (var parameter in parameters)
            {
                if (parameter.Error)
                {
                    return new StatusObj { Error = parameter.Error, Message = parameter.Message, ErrorIndex = x };
                }
                x++;
            }

            return new StatusObj { Error = false, Message = "Success", ErrorIndex = -1 };
        }
    }
}
