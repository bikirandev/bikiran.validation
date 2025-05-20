using System;

namespace Bikiran.Validation
{
    public class ValNumber
    {
        public static StatusObj IsValidateInt(int number, string title, int? min = null, int? max = null)
        {
            if (double.IsNaN(number))
            {
                return new StatusObj { Error = true, Message = "Please enter " + title };
            }

            if (min != null && number < min)
            {
                return new StatusObj { Error = true, Message = title + " should be minimum " + min };
            }

            if (max != null && number > max)
            {
                return new StatusObj { Error = true, Message = title + " should be maximum " + max };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsValidateNumber(double number, string title, double? min = null, double? max = null)
        {
            if (double.IsNaN(number))
            {
                return new StatusObj { Error = true, Message = "Please enter " + title };
            }

            if (min != null && number < min)
            {
                return new StatusObj { Error = true, Message = title + " should be minimum " + min };
            }

            if (max != null && number > max)
            {
                return new StatusObj { Error = true, Message = title + " should be maximum " + max };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }
    }
}
