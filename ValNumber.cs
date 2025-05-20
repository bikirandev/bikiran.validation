using System;

namespace Bikiran.Validation
{
    public class ValNumber
    {
        public static ValidateStatus IsValidateInt(int number, string title, int? min = null, int? max = null)
        {
            if (double.IsNaN(number))
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (min != null && number < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min };
            }

            if (max != null && number > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsValidateNumber(double number, string title, double? min = null, double? max = null)
        {
            if (double.IsNaN(number))
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            if (min != null && number < min)
            {
                return new ValidateStatus { Error = true, Message = title + " should be minimum " + min };
            }

            if (max != null && number > max)
            {
                return new ValidateStatus { Error = true, Message = title + " should be maximum " + max };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
