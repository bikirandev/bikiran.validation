using System;
using Bikiran.Validation.Phone;

namespace Bikiran.Validation
{
    public class ValPhone
    {
        public static ValidateStatus IsValidPhoneNumberFormat(string? pNumber, string title = "Phone Number", bool isOptional = false)
        {
            if (pNumber == null || pNumber.Trim().Length == 0)
            {
                if (isOptional)
                {
                    // If the phone number is optional, return success
                    return new ValidateStatus { Error = false, Message = "Optional" };
                }

                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            // Filter String
            var pNumberFiltered = PhoneNumberOperation.GetPlainNumber(pNumber);
            var pNumberParsed = PhoneNumberOperation.GetParsedNumber(pNumberFiltered);
            if (pNumberParsed == null)
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not valid" };
            }
            var cc = pNumberParsed[0];
            var pn = pNumberParsed[1];

            if (string.IsNullOrEmpty(cc))
            {
                return new ValidateStatus { Error = true, Message = $"Country Code is required with {title}" };
            }

            if (String.IsNullOrEmpty(cc) || String.IsNullOrEmpty(pn) || pn.Length < 6)
            {
                return new ValidateStatus { Error = true, Message = $"{title} is not valid" };
            }

            return new ValidateStatus { Error = false, Message = "Success" };
        }
    }
}
