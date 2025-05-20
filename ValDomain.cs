using System;
using System.Text.RegularExpressions;

namespace Bikiran.Validation
{
    public class ValDomain
    {
        public static ValidateStatus IsValidDomainFormat(string? domainName, string title, bool isOptional = false)
        {
            if (isOptional && (domainName == null || domainName.Length == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            //--VerifyAsync Valid Domain Format
            if (domainName == null || domainName.Trim().Length == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            //--Define a regular expression pattern to match the domain format
            string pattern = @"^([a-zA-Z0-9][a-zA-Z0-9\-]{0,61}[a-zA-Z0-9]\.)+[a-zA-Z]{2,}$";
            var st = Regex.IsMatch(domainName, pattern);
            if (!st)
            {
                return new ValidateStatus { Error = true, Message = title + " is not valid" };
            }

            return new ValidateStatus { Error = false, Message = title + " is Valid" };
        }

        public static ValidateStatus IsValidDomainFormatAll(List<string>? domainName, string title, bool isOptional = false)
        {
            if (isOptional && (domainName == null || domainName.Count == 0))
            {
                return new ValidateStatus { Error = false, Message = "Success" };
            }

            if (domainName == null || domainName.Count == 0)
            {
                return new ValidateStatus { Error = true, Message = "Please enter " + title };
            }

            foreach (var domain in domainName)
            {
                var st = IsValidDomainFormat(domain, title);
                if (st.Error)
                {
                    st.Message = st.Message + ": " + domain;
                    return st;
                }
            }

            return new ValidateStatus { Error = false, Message = title + " is Valid" };
        }
    }
}
