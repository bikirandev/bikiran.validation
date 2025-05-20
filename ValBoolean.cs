using System;

namespace Bikiran.Validation
{
    public class ValBoolean
    {
        public static ValidateStatus IsEqual(string? val1, string? val2, string failedMessage)
        {
            if (val1 != null && val1.Length != 0 && val1 != val2)
            {
                return new ValidateStatus { Error = true, Message = failedMessage };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsTrue(bool val, string failedMessage)
        {
            if (!val)
            {
                return new ValidateStatus { Error = true, Message = failedMessage };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }

        public static ValidateStatus IsFalse(string? val1, string? val2, string successMessage)
        {
            if (val1 != null && val1.Length != 0 && val1 == val2)
            {
                return new ValidateStatus { Error = true, Message = successMessage };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
