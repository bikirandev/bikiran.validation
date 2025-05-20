using System;

namespace Bikiran.Validation
{
    public class ValBoolean
    {
        public static StatusObj IsEqual(string? val1, string? val2, string failedMessage)
        {
            if (val1 != null && val1.Length != 0 && val1 != val2)
            {
                return new StatusObj { Error = true, Message = failedMessage };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsTrue(bool val, string failedMessage)
        {
            if (!val)
            {
                return new StatusObj { Error = true, Message = failedMessage };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }

        public static StatusObj IsFalse(string? val1, string? val2, string successMessage)
        {
            if (val1 != null && val1.Length != 0 && val1 == val2)
            {
                return new StatusObj { Error = true, Message = successMessage };
            }

            return new StatusObj { Error = false, Message = "Success" };
        }
    }
}
